using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EvolvePrankClassLibrary;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Evolve_Prank_Callers
{
	public partial class EvolvePrank : Form
	{
		List<CsvVals> values;
		DbConnect db = DbConnect.Instance();

		public EvolvePrank()
		{
			InitializeComponent();
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{
			if (openEvolveFile.ShowDialog() == DialogResult.OK)
			{
				try
				{
					values = File.ReadAllLines(openEvolveFile.FileName)
					//.Skip(1)
					.Select(v => CsvVals.FromCsv(v))
					.ToList();
					currentData.Items.Clear();
					string boxformat = headerformat(values[0]);
					foreach (CsvVals val in values)
					{
						currentData.Items.Add(string.Format(boxformat, arrconvert(val.Line)));
					}
					//txtNumber.Enabled = true;
					//submitButton.Enabled = true;
					//removeButton.Enabled = true;
					//saveButton.Enabled = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}

		}
		public string headerformat(CsvVals header)
		{
			string boxformat = "";
			for (int i = 0; i < header.Count; i++)
			{

				boxformat += "{" + i + ",-" + (header.Line[i].Length + 3) + "}";

			}
			return boxformat;
		}
		public string[] arrconvert(List<string> linelist)
		{

			string[] line = linelist.ToArray();
			for (int i = 0; i < line.Length; i++)
			{
				if (line[i] == "")
				{
					line[i] = " ";
				}
			}

			return line;
		}

		private void submitButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtNumber.Text.Length != 10)
				{
					throw new Exception("Must be a valid Phone Number.");
				}
				Int64 num = Int64.Parse(txtNumber.Text);
				string lastid = values[values.Count - 1].Line[0];
				if (values.Count != 0)
				{
					int numh = values[0].Count;
					CsvVals val = new CsvVals();
					val.Line.Add((int.Parse(lastid == "" || lastid == "CustomerID" ? "0" : lastid) + 1).ToString());
					val.Line.Add("");
					val.Line.Add(num.ToString());
					for (int i = 3; i < numh; i++)
					{
						val.Line.Add("");
					}
					values.Add(val);
					currentData.Items.Add(string.Format(headerformat(values[0]), val.Line.ToArray()));
					MessageBox.Show(num.ToString("###-###-####") + " was added");
					txtNumber.Text = "";
					txtNumber.Focus();

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			//bool temp = int.TryParse(txtNumber.Text, out int num);


		}
		private void saveButton_Click(object sender, EventArgs e)
		{
			using (saveEvolveFile = new SaveFileDialog() { Filter = "CSV (Comma delimited)|*.csv", ValidateNames = true, FileName = "ANIBlockerUpdate", RestoreDirectory = true })
			{
				saveEvolveFile.InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\Desktop";

				if (saveEvolveFile.ShowDialog() == DialogResult.OK)
				{
					string query = "";
					var csvFilename = saveEvolveFile.FileName;
					StringBuilder csv = new StringBuilder();
					foreach (CsvVals v in values)
					{
						csv.AppendLine(v.ToString());
					}
					bool head = true;
					foreach (CsvVals v in values)
					{
						if (!head)
						{
							query = "INSERT INTO blocklist(CustomerID,CustomerPhoneNumber) VALUES("+v.Line[0]+","+ v.Line[2]+ " )ON DUPLICATE KEY UPDATE CustomerPhoneNumber = "+ v.Line[2] + ";";
							if (db.IsConnect())
							{
								
								var cmd = new MySqlCommand(query, db.Connection);
								var row = cmd.ExecuteNonQuery();
								db.Close();
							}
						}
						head = false;
					}
					File.WriteAllText(csvFilename, csv.ToString());

					/**/
					
					MessageBox.Show("Your data has been successfuly saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void removeButton_Click(object sender, EventArgs e)
		{
			int index = currentData.SelectedIndex;
			if (index != 0 && index != -1)
			{
				values.Remove(values[index]);
				currentData.Items.Remove(currentData.Items[index]);
				string query = "delete from evolve_prank.blocklist where `CustomerID` ="+ index +";";
				if (db.IsConnect())
				{
					var cmd = new MySqlCommand(query, db.Connection);
					var row = cmd.ExecuteNonQuery();
					db.Close();
				}
			}
			else
			{
				MessageBox.Show("Im sorry the row you are trying to remove is a header.", "I.D.10-T", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void txtNumber_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && submitButton.Enabled != false)
			{
				submitButton.PerformClick();
			}
		}

		private void btnTaxDbConvert_Click(object sender, EventArgs e)
		{


			OpenFileDialog taxDialog = new OpenFileDialog() { Filter = "TAB|*tab"};
			if (taxDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					TaxfileConverter taxfileConverter = new TaxfileConverter(taxDialog.FileName);
					SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "CSV|*csv" };
					if (saveFileDialog.ShowDialog() == DialogResult.OK) 
					{
						var csvFilename = saveFileDialog.FileName;
						StringBuilder csv = new StringBuilder();
						foreach (string[] varr in taxfileConverter.Data)
						{
							var line = "";
							for(int i = 0; i< varr.Length; i++)
							{                                
								if (i == 0)
								{
									line = varr[i];
								}
								else
								{
									line += "," + varr[i];
								}                                
							}
							csv.AppendLine(line.ToString());
						}
						File.WriteAllText(csvFilename, csv.ToString());

						MessageBox.Show("Your data has been successfuly saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void tabSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(tabSelect.SelectedTab.Text == "Block Caller")
			{
				Text = "Evolve Prank Callers";
			}
			else
			{
				Text = "Tax Tabfile Converer";
			}
		}

		private void EvolvePrank_Load(object sender, EventArgs e)
		{
			
			db.DatabaseName = "evolve_prank";
			tabSelect.TabPages[1].Enabled = false;
			if (db.IsConnect())
			{
				string query = "SELECT * FROM blocklist";
				var cmd = new MySqlCommand(query, db.Connection);
				var reader = cmd.ExecuteReader();
				string head = "";
				for (int i = 0; i < reader.FieldCount; i++)
				{
					head += (i == 0 ? "":"," ) + reader.GetName(i) ;
				}
				values = new List<CsvVals>();
				CsvVals dbvals = new CsvVals();
				string[] avalues = head.Split(',');
				foreach (string val in avalues)
				{
					dbvals.Line.Add(val);
				}
				values.Add(dbvals);
				currentData.Items.Add(string.Format(headerformat(values[0]), dbvals.Line.ToArray()));
				while (reader.Read())
				{
					dbvals = new CsvVals();
					string data = "";
					for(int i = 0; i < reader.FieldCount; i++)
					{
						data += (i == 0 ? "" : ",") + reader.GetValue(i).ToString();
					}
					avalues = data.Split(',');
					foreach (string val in avalues)
					{
						dbvals.Line.Add(val);
					}
					values.Add(dbvals);
					currentData.Items.Add(string.Format(headerformat(values[0]), dbvals.Line.ToArray()));
				}

				db.Close();
			}
			else
			{
				MessageBox.Show("Connection Failed please contact System Administrator","Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
			
			


		}

		private void tabSelect_Selecting(object sender, TabControlCancelEventArgs e)
		{
			if (!e.TabPage.Enabled)
			{
				e.Cancel = true;
			}
		}

		private void adminCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (adminCheckBox.Checked == true)
			{
				passwordDialog pass = new passwordDialog();
				if (pass.ShowDialog() == DialogResult.OK)
				{
					currentData.Visible = true;
					Size = new Size(290, 450);
					removeButton.Visible = true;
					LoadButton.Visible = true;
					//saveButton.Visible = true;
				}
				else
				{
					adminCheckBox.Checked = false;
				}
			}
			else
			{
				Size = new Size(290, 207);
				currentData.Visible = false;
				removeButton.Visible = false;
				LoadButton.Visible = false;
				//saveButton.Visible = false;
			}
		}
	}
}

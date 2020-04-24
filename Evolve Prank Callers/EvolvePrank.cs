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

namespace Evolve_Prank_Callers
{
    public partial class EvolvePrank : Form
    {
        List<CsvVals> values;
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
                    txtNumber.Enabled = true;
                    submitButton.Enabled = true;
                    removeButton.Enabled = true;
                    saveButton.Enabled = true;
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
            using (saveEvolveFile = new SaveFileDialog() { Filter = "CSV (Comma delimited)|*.csv", ValidateNames = true })
            {

                if (saveEvolveFile.ShowDialog() == DialogResult.OK)
                {
                    var csvFilename = saveEvolveFile.FileName;
                    StringBuilder csv = new StringBuilder();
                    foreach (CsvVals v in values)
                    {
                        csv.AppendLine(v.ToString());
                    }
                    File.WriteAllText(csvFilename, csv.ToString());

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
            }
            else
            {
                MessageBox.Show("Im sorry the row you are trying to remove is a header.", "ID-10-T", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}

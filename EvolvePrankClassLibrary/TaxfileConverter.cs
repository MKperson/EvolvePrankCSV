using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvolvePrankClassLibrary
{
	public class TaxfileConverter
	{

		private List<string[]> data = new List<string[]>();
		public List<string[]> Data { get; set; }
		private string[] header;
		public string[] Header
		{
			get { return header; }
		}

		public TaxfileConverter(string filename)
		{
			StreamReader reader = new StreamReader(File.OpenRead(filename));
			var count = 0;
			while (!reader.EndOfStream)
			{
				if (count == 0)
				{
					var line = reader.ReadLine();
					var values = line.Split('\t');
					header = values;
					count++;
				}
				else
				{
					var line = reader.ReadLine();
					var values = line.Split('\t');
					data.Add(values);
				}
			}
			//int x = Array.IndexOf(header, "Postalcode");
			int[] headerindex = new int[8] { Array.IndexOf(header, "Postalcode"),
			Array.IndexOf(header, "City"),
			Array.IndexOf(header, "State"),
			Array.IndexOf(header, "Statetax"),
			Array.IndexOf(header, "Citytax"),
			Array.IndexOf(header, "Countytax"),
			Array.IndexOf(header, "Districttax"),
			Array.IndexOf(header, "Salestax")};

			header = new string[8] { header[Array.IndexOf(header, "Postalcode")],
				header[Array.IndexOf(header, "City")],
				header[Array.IndexOf(header, "State")],
				header[Array.IndexOf(header, "Statetax")],
				header[Array.IndexOf(header, "Citytax")],
				header[Array.IndexOf(header, "Countytax")],
				header[Array.IndexOf(header, "Districttax")],
				header[Array.IndexOf(header, "Salestax")] };

			Data = new List<string[]>();
			foreach (var rowarr in data)
			{

				Data.Add(new string[8]{rowarr[headerindex[0]],
				rowarr[headerindex[1]],
				rowarr[headerindex[2]],
				float.Parse(rowarr[headerindex[3]]).ToString("0.000000"),
				float.Parse(rowarr[headerindex[4]]).ToString("0.000000"),
				float.Parse(rowarr[headerindex[5]]).ToString("0.000000"),
				float.Parse(rowarr[headerindex[6]]).ToString("0.000000"),
				float.Parse(rowarr[headerindex[7]]).ToString("0.000000")});
			}
			var x = removeDups();

		}
		private int removeDups()
		{
			int count = 0;
			List<string[]> holder = new List<string[]>(Data);
			foreach (var arr in holder)
			{
				if (compareAndRemove(arr))
				{
					count++;
					continue;
				}
			}
			return count;
		}
		private bool compareAndRemove(string[] line)
		{
			foreach (var arr in Data)
			{
				if (arr[0] == line[0] && arr[1] == line[1] && arr[2] == line[2])
				{
					if (float.Parse(arr[7]) < float.Parse(line[7]))
					{
						Data.Remove(arr);
						return true;
					}
				}

			}

			return false;
		} }

		/*private void removeDups(string FileName,string SalesTaxFile)
		{
			
			
				using (FileStream InputFile = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					InitProg(InputFile.Length);
					using (FileStream OutputFile = new FileStream(SalesTaxFile, FileMode.Create, FileAccess.Write, FileShare.None))
					{
						using (StreamReader SR = new StreamReader(InputFile))
						{
							using (StreamWriter SW = new StreamWriter(OutputFile))
							{
								while (!SR.EndOfStream)
								{
									bool WriteAllowed = false;
									if (!ReadHeader)
									{
										if (HeaderRow)
										{
											string Line = SR.ReadLine();
											WriteAllowed = false;
										}
									}
									else
										WriteAllowed = true;
									if (WriteAllowed)
									{
										string Line = SR.ReadLine();
										string[] RowData = Line.Split(Delimiter);
										string Zip = RowData[ZipColumnIdx];
										string Rate = RowData[RateColumnIdx];
										if (Zip != "" & Rate != "" && Information.IsNumeric(Rate))
										{
											TaxRate FoundRate = TaxRates.Find(TaxRate TR =>
											{
												return TR.Zip == Zip;
											});
											if (FoundRate != null)
											{
												if (Rate > FoundRate.Rate)
													FoundRate.Rate = System.Convert.ToDecimal(Rate);
											}
											else
												TaxRates.Add(new TaxRate() { Zip = Zip, Rate = System.Convert.ToDecimal(Rate) });
										}
										IncProg(InputFile.Position);
										Status("Reading Update File: " + (InputFile.Position / (double)InputFile.Length).ToString("P2"));
									}
									if (!ReadHeader)
										ReadHeader = true;
								}
								Thread.Sleep(600);
								InitProg(TaxRates.Count);
								for (int Idx = 0; Idx <= TaxRates.Count - 1; Idx++)
								{
									TaxRate TR = TaxRates(Idx);
									SW.WriteLine(TR.Zip + "|" + TR.Rate.ToString("#0.000000"));
									IncProg(Idx + 1);
									Status("Writing Update File: " + ((Idx + 1) / (double)TaxRates.Count).ToString("P2"));
								}
								SW.Close();
							}
							SR.Close();
						}
						OutputFile.Close();
					}
					InputFile.Close();
				}
			}

		}

	*/


	
}

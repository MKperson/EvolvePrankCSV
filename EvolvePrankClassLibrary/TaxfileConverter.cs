using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolvePrankClassLibrary
{
    public class TaxfileConverter
    {

        private List<string[]> data = new List<string[]>();
        private List<string[]> Data = new List<string[]>();
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
                if (count == 0) {
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
        }
        


    }
}

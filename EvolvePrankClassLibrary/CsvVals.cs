using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EvolvePrankClassLibrary
{
    public class CsvVals
    {
        public List<string> Line = new List<string>();

        /*string CustomerID, CustomerEmail, CustomerPhoneNumber, CustomerSecondPhoneNumber, CustomerAccount,
            CustomerTimeZone, CustomerLocation, CustomerCountry, CustomerStateCode,
            CustomerRating, FullName, Keywords, Comment, CustomerNameLink, CustomerManagementLink,
            ProductLink, LocationLink, OrganizationCode, PreferredRoutingCode, CustomerBillingCode;
    */
        public static CsvVals FromCsv(string csvLine)
        {

            string[] values = csvLine.Split(',');
            CsvVals vals = new CsvVals();
            foreach (string val in values)
            {
                vals.Line.Add(val);
            }

            return vals;

        }

        public override string ToString()
        {
            string linestring = "";
            int count = 0;
            foreach (string val in Line)
            {
                if (count != 0)
                {
                    linestring += ",";
                }
                linestring += val;
                count++;
            }
            return linestring;
        }
        public int Count
        {
            get { return Line.Count; }
        }


    }
}

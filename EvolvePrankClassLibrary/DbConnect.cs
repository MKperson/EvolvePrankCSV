using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EvolvePrankClassLibrary
{
    public class DbConnect
    {
        private string connetionstring;
        public SqlConnection cnn;
        public DbConnect()
        {
            connetionstring = "Dsn=Evolve Prank;server={tms-hvgs-mysql};uid=root;database=evolve_prank;port=3306";
            cnn = new SqlConnection(connetionstring);
            
        }
        public void Open() 
        {
            cnn.Open();
        }
        public void Close() 
        {
            cnn.Close();
        }
        


    }
}

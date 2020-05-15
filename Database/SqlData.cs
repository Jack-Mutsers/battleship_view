using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class SqlData
    {
        //private string _connectionString { get; } = "server={server};userid={user};password={password};database={database};";
        private string _connectionString { get; } = "Server={server},1433;User ID={user};Password={password};database={database};Trusted_Connection=False;Encrypt=True;";


        public string connectionString 
        {
            get 
            {
                string link = _connectionString;
                link = link.Replace("{server}", server);
                link = link.Replace("{user}", user);
                link = link.Replace("{password}", password);
                link = link.Replace("{database}", database);
                return link;
            } 
        }

        private string server = @"S2-battleships.database.windows.net";
        private string user = "StiptonShip";
        private string password = "y3gH1Za32Qdrc84";
        private string database = "ArcadeScores";

        //private string server = @"localhost";
        //private string user = "root";
        //private string password = "";
        //private string database = "proftaak";
        
        
        
        //public string connectionString = "server=localhost;userid=root;password=;database=proftaak;";
    }
}

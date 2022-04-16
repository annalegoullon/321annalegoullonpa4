using System;
using System.IO;
using System.Collections.Generic;
using pa4_annalegoullon.api.Interfaces;
using pa4_annalegoullon.api.Models;
using MySql.Data.MySqlClient;

namespace pa4_annalegoullon.api
{
    public class ConnectionString{ //database connection string obj
        public string cs{get;set;}

        public ConnectionString(){
            string server = "lfmerukkeiac5y5w.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "s2rxbtks83o3a763";
            string port = "3306";
            string userName = "c4rbcu387dqsster";
            string password = "nr1757p4344z7e51";
            cs = $@"server = {server};user={userName};database={database};port={port};password={password};";
        }
    }
}
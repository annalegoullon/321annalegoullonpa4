using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.IO;
using pa4_annalegoullon.api.Interfaces;
using pa4_annalegoullon.api.Models;
using MySql.Data.MySqlClient;

namespace pa4_annalegoullon.api.Database{
    
    public class DeleteSong : IDeleteSongs{
        public void Delete(Song s){
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            
            using var cmd = new MySqlCommand("DELETE FROM songs WHERE title = '" + s.SongTitle+"'",con);
            
            
            cmd.ExecuteNonQuery();
        }

    }
}

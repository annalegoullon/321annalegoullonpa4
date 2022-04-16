using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.IO;
using pa4_annalegoullon.api.Interfaces;
using pa4_annalegoullon.api.Database;
using pa4_annalegoullon.api.Models;
using MySql.Data.MySqlClient;

namespace pa4_annalegoullon.api.Database{
    public class UpdateSong : IUpdateSongs{
        public void Update(Song s){
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            string fav = "y";
            con.Open();

            using var cmd = new MySqlCommand(@"UPDATE songs set timeadded = @timeadded, deleted = @deleted, favorited = @favorited WHERE title=@title");
            cmd.Connection = con;
            //cmd.Parameters.AddWithValue("@id",s.SongID);
            cmd.Parameters.AddWithValue("@title",s.SongTitle);
            cmd.Parameters.AddWithValue("@timeadded",s.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted",s.Deleted);
            cmd.Parameters.AddWithValue("@favorited",fav);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
            
        }

    }
}
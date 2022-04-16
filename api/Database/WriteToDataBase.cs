using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.IO;
using pa4_annalegoullon.api.Interfaces;
using pa4_annalegoullon.api.Models;
using MySql.Data.MySqlClient;

namespace pa4_annalegoullon.api.Database
{
    public class WriteToDataBase : ICreateSongs
    {
        public void Create(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            
            //writes song into database
            string stm = @"INSERT INTO songs(id,title,timeadded, deleted,favorited) VALUES(@id,@title,@timeadded,@deleted,@favorited)";

            using var cmd = new MySqlCommand(stm,con);

            string deleted = "n";
            

            cmd.Parameters.AddWithValue("@id",song.SongID);
            cmd.Parameters.AddWithValue("@title",song.SongTitle);
            cmd.Parameters.AddWithValue("@timeadded",song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", deleted);
            cmd.Parameters.AddWithValue("@favorited",song.Favorited) ;

            cmd.Prepare();

            cmd.ExecuteNonQuery();
            
        }

         public static void WriteAllToDatabase(List<Song> Playlist) { // write songs in playlist to songs.txt
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //deletes song table if it exists
            string drop = @"DROP TABLE if exists songs";

            using var cmd = new MySqlCommand(drop,con);
            cmd.ExecuteNonQuery();

            WriteToDataBase.CreateSongTable();

            string stm = @"INSERT INTO songs(id,title,timeadded, deleted,favorited) VALUES(@id,@title,@timeadded,@deleted,@favorited)";

            //loop to write each song in list to the database
            foreach (Song song in Playlist) {
                using var c = new MySqlCommand(stm,con);
                string deleted = "n";
                string favorite = "n";

                c.Parameters.AddWithValue("@id",song.SongID);
                c.Parameters.AddWithValue("@title",song.SongTitle);
                c.Parameters.AddWithValue("@timeadded",song.SongTimestamp);
                c.Parameters.AddWithValue("@deleted", deleted);
                cmd.Parameters.AddWithValue("@favorited", favorite);

                c.Prepare();

                c.ExecuteNonQuery();

                
            }

            
        } 
        //creates song table in the database
        public static void CreateSongTable(){

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id INTEGER PRIMARY KEY,title TEXT, timeadded DATETIME, deleted TEXT,favorited TEXT)";

            using var cmd = new MySqlCommand(stm,con);

            cmd.ExecuteNonQuery();
        }
    }
}
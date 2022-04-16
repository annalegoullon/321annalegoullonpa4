using System;
using System.IO;
using System.Collections.Generic;
using pa4_annalegoullon.api.Interfaces;
using pa4_annalegoullon.api.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
namespace pa4_annalegoullon.api.Database
{
    public class ReadFromDatabase : IReadSongs
    {
        public List<Song> GetAll() { // read in songs from database
            List<Song> songs = new List<Song>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"Select * from songs";

            using var cmd = new MySqlCommand(stm,con);
            using MySqlDataReader reader = cmd.ExecuteReader();

            //read in each song from database and add to list
            while(reader.Read()){
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                DateTime time = reader.GetDateTime(2);
                string deleted = reader.GetString(3);
                string favorite = reader.GetString(4);
                songs.Add(new Song(){SongID = id, SongTitle = title, SongTimestamp = time, Deleted = deleted,Favorited = favorite});
            }
            //sort the list by date
            songs.Sort((x, y) => y.SongTimestamp.CompareTo(x.SongTimestamp));
            reader.Close();

        
            return songs;
        }

        public Song GetOne(int id)
        {
            Song s = new Song();
            return s;

        }
        public static void CreateSongTable(){

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id INTEGER PRIMARY KEY AUTO_INCREMENT,title TEXT, timeadded DATETIME, deleted TEXT, favorited TEXT)";

            using var cmd = new MySqlCommand(stm,con);

            cmd.ExecuteNonQuery();
        }

        public void OpenDatabase(){
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //deletes song table if it exists
           // string drop = @"DROP TABLE if exists songs";

           // using var cmd = new MySqlCommand(drop,con);
           // cmd.ExecuteNonQuery();

           // ReadFromDatabase.CreateSongTable();

          //  Song a = new Song(){SongID = 123, SongTitle = "Grenade", SongTimestamp = DateTime.Now, Deleted = "n", Favorited = "n"};
           // Song b = new Song(){SongID = 1234, SongTitle = "7 rings", SongTimestamp = DateTime.Now, Deleted = "n", Favorited = "n"};

          //  WriteToDataBase w = new WriteToDataBase();
          //  w.Create(a);
           // w.Create(b);
        }
    }
}
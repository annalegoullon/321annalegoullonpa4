using System.Collections.Generic;
using pa4_annalegoullon.api.Models;

namespace pa4_annalegoullon.api.Interfaces
{
    public interface ISongUtilities
    {
        public List<Song> playlist { get; set; }
         public void AddSong();
         public void DeleteSong();
         public void EditSong();
         public void PrintPlaylist();
    }
}
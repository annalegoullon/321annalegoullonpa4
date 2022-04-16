using System.Collections.Generic;
using pa4_annalegoullon.api.Models;

namespace pa4_annalegoullon.api.Interfaces
{
    public interface IReadSongs
    {
        public List<Song> GetAll();
        public Song GetOne(int id);
         
    }
}
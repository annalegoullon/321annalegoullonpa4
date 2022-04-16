using System;
using pa4_annalegoullon.api.Models;
using pa4_annalegoullon.api.Interfaces;
using pa4_annalegoullon.api.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace pa4_annalegoullon.api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        // GET: api/Song
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Song>Get()
        {
            ReadFromDatabase readObj = new ReadFromDatabase();
            readObj.OpenDatabase();
            return readObj.GetAll();

        }

        // GET: api/Song/5
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int id)
        {
            ReadFromDatabase readObj = new ReadFromDatabase();
            readObj.OpenDatabase();
            return readObj.GetOne(id);
        }

        // POST: api/Song
        [HttpPost]
        [EnableCors("AnotherPolicy")]
        public void Post([FromBody] Song value){
            ICreateSongs insert = new WriteToDataBase();
            insert.Create(value);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Song song){
            IUpdateSongs update = new UpdateSong();
            update.Update(song);
        }

        // DELETE: api/Song/5
         [EnableCors("AnotherPolicy")]
        [HttpDelete]
        public void Delete([FromBody] Song s){ 
           IDeleteSongs delete = new DeleteSong();
           delete.Delete(s);
        }
    }
}

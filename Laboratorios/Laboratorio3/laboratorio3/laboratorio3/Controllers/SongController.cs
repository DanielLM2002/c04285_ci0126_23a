using laboratorio3.Models;
using Microsoft.AspNetCore.Mvc;

namespace laboratorio3.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Index()
        {
            var songs = getListOfSongs();
            ViewBag.MainTitle = "These are my favorite Songs of all time"; return View(songs);
        }
        private List<SongModel> getListOfSongs()
        {
            List<SongModel> songs = new List<SongModel>(); songs.Add(new SongModel
            {
                Id = 1,
                SongName = "What you know",
                SongGenre = "Indie/Rock",
                Album = "Tourist History",
                Artist = "Two Door Cinema Club",
                ProducedBy = "Elliot James",
                ReleaseDate = new DateTime(2011, 2, 7)
            });
            songs.Add(new SongModel
            {
                Id = 2,
                SongName = "Cigarette Daydreams",
                SongGenre = "Indie/rock",
                Album = "Melophobia",
                Artist = "Cage the Elephant",
                ProducedBy = "Jay Joyce",
                ReleaseDate = new DateTime(2014, 8, 26)

            });
            songs.Add(new SongModel
            {
                Id = 3,
                SongName = "Family ties",
                SongGenre = "Rap/Hip hop",
                Album = "The Melodic Blue",
                Artist = "Baby Keem/Kendrick Lamar",
                ProducedBy = "Baby Keem",
                ReleaseDate = new DateTime(2021, 8, 27)

            });
            return songs;
        }
    }
}

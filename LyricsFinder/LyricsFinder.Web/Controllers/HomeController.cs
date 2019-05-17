using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LyricsFinder.Web.Models;
using LyricsFinder.Web.Services;

namespace LyricsFinder.Web.Controllers
{
    public class HomeController : Controller
    {
        ILyricsSearchEngine _lyricsSearchEngine;

        public HomeController(ILyricsSearchEngine lyricsSearchEngine)
        {
            _lyricsSearchEngine = lyricsSearchEngine;
        }

        public IActionResult Index()
        {
            var lyricModel = new LyricModel();

            return View(lyricModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string SongTitle, string BandName)
        {
            var lyricModel = new LyricModel();
            lyricModel.Title = SongTitle;
            lyricModel.BandName = BandName;

            lyricModel.Lyric = await _lyricsSearchEngine.RetrieveLyricAsync(SongTitle, BandName);

            return View("Index", lyricModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

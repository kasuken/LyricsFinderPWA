using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyricsFinder.Web.Services
{
    public class LyricWikiEngine : ILyricsSearchEngine
    {
        public async Task<string> RetrieveLyricAsync(string songTitle, string bandName)
        {
            var band = bandName;
            var title = songTitle.Replace(" ", "_");

            var config = Configuration.Default.WithDefaultLoader();
            var address = $"https://lyrics.fandom.com/wiki/{band}:{title}";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);

            var lyricBox = document.QuerySelector(".lyricbox");
            var lyricText = lyricBox.InnerHtml;

            return lyricText;
        }
    }
}

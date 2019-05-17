using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyricsFinder.Web.Services
{
    public interface ILyricsSearchEngine
    {

         Task<string> RetrieveLyricAsync(string songTitle, string bandName);

    }
}

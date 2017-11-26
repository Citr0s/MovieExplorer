using System.Collections.Generic;
using MovieExplorer.Core.Communication;

namespace MovieExplorer.Data.Film
{
    public class FilmResponse : CommunicationResponse
    {
        public FilmResponse()
        {
            FilmData = new List<FilmData>();
        }

        public List<FilmData> FilmData { get; set; }
    }
}
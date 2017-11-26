using System.Collections.Generic;
using MovieExplorer.Core.Communication;
using MovieExplorer.Data.Film;

namespace MovieExplorer.Services.Film
{
    public class FindByTitleResponse : CommunicationResponse
    {
        public List<FilmData> Films { get; set; }
    }
}
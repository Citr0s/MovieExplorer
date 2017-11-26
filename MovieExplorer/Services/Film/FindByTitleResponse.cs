using System.Collections.Generic;
using MovieExplorer.Core.Communication;
using MovieExplorer.ViewModels;

namespace MovieExplorer.Services.Film
{
    public class FindByTitleResponse : CommunicationResponse
    {
        public FindByTitleResponse()
        {
            Films = new List<FilmModel>();
        }

        public List<FilmModel> Films { get; set; }
    }
}
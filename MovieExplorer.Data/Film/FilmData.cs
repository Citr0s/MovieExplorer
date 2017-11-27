using System.Collections.Generic;

namespace MovieExplorer.Data.Film
{
    public class FilmData
    {
        public FilmData()
        {
            Search = new List<SearchModel>();
        }

        public List<SearchModel> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }

        public class SearchModel
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string ImdbId { get; set; }
            public string Type { get; set; }
            public string Poster { get; set; }
        }
    }
}
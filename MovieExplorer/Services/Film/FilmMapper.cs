using System.Collections.Generic;
using MovieExplorer.Data.Film;
using MovieExplorer.ViewModels;

namespace MovieExplorer.Services.Film
{
    public class FilmMapper
    {
        public static List<FilmModel> Map(FilmData filmData)
        {
            var response = new List<FilmModel>();

            foreach (var film in filmData.Search)
            {
                if (film.Poster.ToUpper().Equals("N/A"))
                    continue;

                var filmModel = new FilmModel
                {
                    ImdbIdentifier = film.ImdbId,
                    Poster = film.Poster
                };

                response.Add(filmModel);
            }

            return response;
        }

        public static FilmModel MapDetails(FilmDetail filmDetails)
        {
            return new FilmModel
            {
                Poster = filmDetails.Poster
            };
        }
    }
}
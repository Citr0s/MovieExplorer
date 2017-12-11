using System.Collections.Generic;
using System.Linq;
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
                    Identifier = film.ImdbId,
                    Poster = film.Poster
                };

                response.Add(filmModel);
            }

            return response;
        }

        public static FilmModel MapDetails(FilmDetail filmDetails)
        {
            var response = new FilmModel
            {
                Identifier = filmDetails.ImdbId,
                Title = filmDetails.Title,
                Poster = filmDetails.Poster,
                Genre = filmDetails.Genre,
                Released = filmDetails.Released,
                Year = filmDetails.Year,
                Plot = filmDetails.Plot
            };

            if (filmDetails.Ratings.Count == 0)
                return response;

            var rating = filmDetails.Ratings.First();
            response.Ratings = $"{rating.Source}: {rating.Value} ";
            return response;
        }
    }
}
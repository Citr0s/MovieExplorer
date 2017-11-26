using System.Collections.Generic;
using MovieExplorer.Data.Film;
using MovieExplorer.ViewModels;

namespace MovieExplorer.Services.Film
{
    public class FilmMapper
    {
        public static List<FilmModel> Map(List<FilmData> filmData)
        {
            var response = new List<FilmModel>();

            foreach (var film in filmData)
            {
                if (string.IsNullOrEmpty(film.Poster.Thumb))
                    continue;

                var filmModel = new FilmModel
                {
                    Poster = film.Poster.Thumb
                };

                response.Add(filmModel);
            }

            return response;
        }
    }
}
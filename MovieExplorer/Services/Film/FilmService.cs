using System.Collections.Generic;
using MovieExplorer.Data.Film;
using MovieExplorer.ViewModels;

namespace MovieExplorer.Services.Film
{
    public class FilmService
    {
        private readonly FilmRepository _filmRepository;

        public FilmService(FilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public FindByTitleResponse FindByTitle(string title)
        {
            var response = new FindByTitleResponse();

            var filmLookup = _filmRepository.FindByTitle(title);
            filmLookup.Wait();

            var filmLookupResult = filmLookup.Result;

            if (filmLookupResult.HasError)
            {
                response.AddError(filmLookupResult.Error);
                return response;
            }

            response.Films = FilmMapper.Map(filmLookupResult.FilmData);
            return response;
        }
    }

    public class FilmMapper
    {
        public static List<FilmModel> Map(List<FilmData> filmData)
        {
            var response = new List<FilmModel>();

            foreach (var film in filmData)
            {
                if (string.IsNullOrEmpty(film.Poster.Thumb) && string.IsNullOrEmpty(film.Poster.Large))
                    continue;

                if (string.IsNullOrEmpty(film.Poster.Thumb))
                    film.Poster.Thumb = film.Poster.Large;

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

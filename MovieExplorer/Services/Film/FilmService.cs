using MovieExplorer.Data.Film;

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

        public FindDetaulsResponse FindDetails(string imdbIdentifier)
        {
            var response = new FindDetaulsResponse();

            var filmLookup = _filmRepository.FindDetails(imdbIdentifier);
            filmLookup.Wait();

            var filmLookupResult = filmLookup.Result;

            if (filmLookupResult.HasError)
            {
                response.AddError(filmLookupResult.Error);
                return response;
            }

            response.FilmDetails = FilmMapper.MapDetails(filmLookupResult.FilmDetails);
            return response;
        }
    }
}

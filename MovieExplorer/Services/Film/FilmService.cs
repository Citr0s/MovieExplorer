using System.Threading.Tasks;
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

        public async Task<FindByTitleResponse> FindByTitle(string title)
        {
            var response = new FindByTitleResponse();
            var filmLookup = await _filmRepository.FindByTitle(title);

            if (filmLookup.HasError)
            {
                response.AddError(filmLookup.Error);
                return response;
            }

            response.Films = FilmMapper.Map(filmLookup.FilmData);
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

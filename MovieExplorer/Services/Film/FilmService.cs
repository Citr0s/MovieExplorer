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

        public async Task<FindDetaulsResponse> FindDetails(string imdbIdentifier)
        {
            var response = new FindDetaulsResponse();
            var filmLookup = await _filmRepository.FindDetails(imdbIdentifier);

            if (filmLookup.HasError)
            {
                response.AddError(filmLookup.Error);
                return response;
            }

            response.FilmDetails = FilmMapper.MapDetails(filmLookup.FilmDetails);
            return response;
        }
    }
}

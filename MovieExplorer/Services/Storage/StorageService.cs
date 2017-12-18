using System.Collections.Generic;
using System.Linq;
using Windows.Storage;
using MovieExplorer.ViewModels;
using Newtonsoft.Json;

namespace MovieExplorer.Services.Storage
{
    public class StorageService
    {
        private readonly ApplicationDataContainer _localStorage;

        public StorageService()
        {
            _localStorage = ApplicationData.Current.LocalSettings;
        }

        public List<FilmModel> GetFromStorage()
        {
            var response = new List<FilmModel>();
            
            if (_localStorage.Values.ContainsKey("Films"))
                response.AddRange(JsonConvert.DeserializeObject<List<FilmModel>>((string)_localStorage.Values["Films"]));

            return response;
        }

        public void AddToStorage(FilmModel newFilm)
        {
            var films = GetFromStorage();

            if (films.All(x => x.Identifier != newFilm.Identifier))
                films.Add(newFilm);

            _localStorage.Values["Films"] = JsonConvert.SerializeObject(films);
        }

        public void ClearStorage()
        {
            _localStorage.Values["Films"] = JsonConvert.SerializeObject(new List<FilmDetails>());
        }
    }
}

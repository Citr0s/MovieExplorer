using System.Collections.Generic;
using MovieExplorer.Data.Cinema;

namespace MovieExplorer.Services.Cinema
{
    public class CinemaMapper
    {
        public static List<CinemaInfo> Map(CinemaData cinemas)
        {
            var response = new List<CinemaInfo>();
            foreach (var cinema in cinemas.Cinemas)
            {
                response.Add(new CinemaInfo
                {
                    Name = cinema.Name,
                    DistanceDescription = $"{cinema.Distance} miles away"
                });
            }
            return response;
        }
    }
}
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
                response.Add(new CinemaInfo
                {
                    Identifier = cinema.Id,
                    Name = cinema.Name,
                    DistanceDescription = $"{cinema.Distance} miles away"
                });
            return response;
        }

        public static List<Listing> MapListings(List<CinemaListing.Listing> cinemaListingListings)
        {
            var response = new List<Listing>();
            foreach (var cinema in cinemaListingListings)
                response.Add(new Listing
                {
                    Title = cinema.Title,
                    Times = cinema.Times
                });
            return response;
        }
    }
}
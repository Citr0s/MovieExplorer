using System.Collections.Generic;

namespace MovieExplorer.Data.Cinema
{
    public class CinemaListing
    {
        public string Status { get; set; }
        public List<Listing> Listings { get; set; }

        public class Listing
        {
            public string Title { get; set; }
            public List<string> Times { get; set; }
        }
    }
}
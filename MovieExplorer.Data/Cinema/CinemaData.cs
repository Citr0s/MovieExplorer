using System.Collections.Generic;

namespace MovieExplorer.Data.Cinema
{
    public class CinemaData
    {
        public string Postcode { get; set; }
        public List<CinemaInformation> Cinemas { get; set; }

        public class CinemaInformation
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public double Distance { get; set; }
        }
    }
}
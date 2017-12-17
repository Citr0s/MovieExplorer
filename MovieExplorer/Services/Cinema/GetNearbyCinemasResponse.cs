using System.Collections.Generic;
using MovieExplorer.Core.Communication;

namespace MovieExplorer.Services.Cinema
{
    public class GetNearbyCinemasResponse : CommunicationResponse
    {
        public GetNearbyCinemasResponse()
        {
            Cinemas = new List<CinemaInfo>();
        }

        public List<CinemaInfo> Cinemas { get; set; }
    }
}
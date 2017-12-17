using System.Collections.Generic;
using MovieExplorer.Core.Communication;

namespace MovieExplorer.Services.Cinema
{
    public class GetShowingsResponse : CommunicationResponse
    {
        public GetShowingsResponse()
        {
            Listings = new List<Listing>();
        }

        public List<Listing> Listings { get; set; }
    }
}
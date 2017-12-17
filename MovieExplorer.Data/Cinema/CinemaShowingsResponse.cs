using MovieExplorer.Core.Communication;

namespace MovieExplorer.Data.Cinema
{
    public class CinemaShowingsResponse : CommunicationResponse
    {
        public CinemaListing CinemaListing { get; set; }
    }
}
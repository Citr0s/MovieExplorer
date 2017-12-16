using MovieExplorer.Core.Communication;

namespace MovieExplorer.Data.Cinema
{
    public class CinemaResponse : CommunicationResponse
    {
        public CinemaData Cinemas { get; set; }
    }
}
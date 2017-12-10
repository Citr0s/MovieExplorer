using MovieExplorer.Core.Communication;

namespace MovieExplorer.Services.Trailer
{
    internal class TrailerResponse : CommunicationResponse
    {
        public string Trailer { get; set; }
    }
}
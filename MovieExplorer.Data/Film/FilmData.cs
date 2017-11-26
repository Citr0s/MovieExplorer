using System.Collections.Generic;

namespace MovieExplorer.Data.Film
{
    public class FilmData
    {
        public FilmData()
        {
            Trailer = new List<TrailerInfo>();
            Cast = new List<CastInfo>();
            Genre = new List<string>();
            Writers = new List<string>();
            Stars = new List<string>();
        }

        public string Title { get; set; }
        public string ContentRating { get; set; }
        public string OriginalTitle { get; set; }
        public ExtraInfo Metadata { get; set; }
        public string ReleaseDate { get; set; }
        public string Director { get; set; }
        public BasicInfo Url { get; set; }
        public string Year { get; set; }
        public List<TrailerInfo> Trailer { get; set; }
        public string Length { get; set; }
        public List<CastInfo> Cast { get; set; }
        public string ImdbId { get; set; }
        public string Rating { get; set; }
        public List<string> Genre { get; set; }
        public string RatingCount { get; set; }
        public string Storyline { get; set; }
        public string Description { get; set; }
        public List<string> Writers { get; set; }
        public List<string> Stars { get; set; }
        public PosterInfo Poster { get; set; }

        public class ExtraInfo
        {
            public ExtraInfo()
            {
                Languages = new List<string>();
                FilmingLocations = new List<string>();
                AlsoKnownAs = new List<string>();
                Countries = new List<string>();
                SoundMix = new List<string>();
            }

            public List<string> Languages { get; set; }
            public string AspRetio { get; set; }
            public List<string> FilmingLocations { get; set; }
            public List<string> AlsoKnownAs { get; set; }
            public List<string> Countries { get; set; }
            public string Gross { get; set; }
            public List<string> SoundMix { get; set; }
            public string Budget { get; set; }
        }

        public class BasicInfo
        {
            public string Url { get; set; }
            public string Year { get; set; }
            public string Title { get; set; }
        }

        public class CastInfo
        {
            public string Character { get; set; }
            public string Image { get; set; }
            public string Link { get; set; }
            public string Name { get; set; }
        }

        public class PosterInfo
        {
            public string Large { get; set; }
            public string Thumb { get; set; }
        }

        public class TrailerInfo
        {
            public string MimeType { get; set; }
            public string Definition { get; set; }
            public string VideoUrl { get; set; }
        }
    }
}
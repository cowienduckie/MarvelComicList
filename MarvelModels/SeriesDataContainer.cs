using System.Collections.Generic;

namespace MarvelComicList.MarvelModels
{
    public class SeriesDataContainer
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<Series> Results { get; set; }
    }
}
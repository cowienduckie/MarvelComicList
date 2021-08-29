using System.Collections.Generic;

namespace MarvelComicList.MarvelModels
{
    public class SeriesList
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<SeriesSummary> Items { get; set; }
        public int Returned { get; set; }
    }
}
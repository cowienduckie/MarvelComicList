using System.Collections.Generic;

namespace MarvelComicList.MarvelModels
{
    public class CreatorList
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<CreatorSummary> Items { get; set; }
        public int Returned { get; set; }
    }
}
using System.Collections.Generic;

namespace MarvelComicList.MarvelModels
{
    public class EvenList
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<EventSummary> Items { get; set; }
        public int Returned { get; set; }
    }
}
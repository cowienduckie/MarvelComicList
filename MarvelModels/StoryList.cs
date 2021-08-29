using System.Collections.Generic;

namespace MarvelComicList.MarvelModels
{
    public class StoryList
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<StorySummary> Items { get; set; }
        public int Returned { get; set; }
    }
}
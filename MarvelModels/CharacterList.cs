using System.Collections.Generic;

namespace MarvelComicList.MarvelModels
{
    public class CharacterList
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<CharacterSummary> Items { get; set; }
        public int Returned { get; set; }
    }
}
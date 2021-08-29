using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

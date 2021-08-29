using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelComicList.MarvelModels
{
    public class ComicList
    {
        public int Available { get; set; }       
        public string CollectionURI { get; set; }
        public List<ComicSummary> Items { get; set; }
        public int Returned { get; set; }
    }
}

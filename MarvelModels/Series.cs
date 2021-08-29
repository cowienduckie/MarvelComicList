using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelComicList.MarvelModels
{
    public class Series
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceURI { get; set; }
        public List<Link> URLs { get; set; }        
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Rating { get; set; }
        public string Type { get; set; }
        public string Modified { get; set; }
        public Image Thumbnail { get; set; }
        public CreatorList Creators { get; set; }        
        public CharacterList Characters { get; set; }        
        public StoryList Stories { get; set; }
        public ComicList Comics { get; set; }
        public EvenList Events { get; set; }
        public SeriesSummary Next { get; set; }
        public SeriesSummary Previous { get; set; }       
    }
}

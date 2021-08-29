using System.Collections.Generic;

namespace MarvelComicList.MarvelModels
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public Image Thumbnail { get; set; }
        public string ResourceURI { get; set; }
        public ComicList Comics { get; set; }
        public SeriesList Series { get; set; }
        public StoryList Stories { get; set; }
        public EvenList Events { get; set; }
        public List<Link> URLs { get; set; }
    }
}
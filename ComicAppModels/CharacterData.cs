using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarvelComicList.ComicAppModels
{
    public class CharacterData
    {
        //Character Info
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Thumbnail { get; set; }

        [Display(Name = "Character wiki")]
        public string WikiLink { get; set; }

        [Display(Name = "Related comics")]
        public string ComicLink { get; set; }

        //Related Series Info
        public List<SeriesData> Series { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelComicList.ComicAppModels
{
    public class SeriesData
    {
        public int ID { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Thumbnail { get; set; }

        [Display (Name = "Start year")]
        public int StartYear { get; set; }

        [Display (Name = "Type")]
        public string Type { get; set; }

        [Display (Name = "Previous Series")]
        public SeriesData PreviousSeries { get; set;  }

        [Display (Name = "Next Series")]
        public SeriesData NextSeries { get; set; }

        [Display(Name = "Series details")]
        public string DetailLink { get; set; }

        public List<CharacterData> Characters { get; set; }
    }
}

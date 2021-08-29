using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelComicList.MarvelModels;

namespace MarvelComicList.Repositories
{
    public interface IMarvelRepository
    {
        CharacterDataWrapper GetCharacterList(string name, string orderBy = null, int page = 1);
        SeriesDataWrapper GetSeriesList(string title, string orderBy = null, int startYear = -1, int page = 1);
        CharacterDataWrapper GetCharacter(int id);
        SeriesDataWrapper GetSeries(int id);
        SeriesDataWrapper GetRelatedSeries(int id, int page);
        CharacterDataWrapper GetRelatedCharacter(int id, int page = 1);
    }
}

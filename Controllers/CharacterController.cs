using MarvelComicList.ComicAppModels;
using MarvelComicList.MarvelModels;
using MarvelComicList.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarvelComicList.Controllers
{
    public class CharacterController : Controller
    {
        private readonly IMarvelRepository _marvelRepository;

        // Dependency Injection
        public CharacterController(IMarvelRepository marvelRepo)
        {
            _marvelRepository = marvelRepo;
        }

        // GET: Character
        public IActionResult Index(string name, string orderBy, int page = 1)
        {
            CharacterDataWrapper characterDataWrapper = _marvelRepository.GetCharacterList(name, orderBy, page);

            if (characterDataWrapper == null)
            {
                return NotFound();
            }

            List<CharacterData> viewModel = new List<CharacterData>();

            List<Character> characters = characterDataWrapper.Data.Results;

            characters.ForEach(character =>
            {
                CharacterData newChar = new CharacterData();

                newChar.ID = character.ID;
                newChar.Name = character.Name;
                newChar.Description = character.Description;
                newChar.Thumbnail = character.Thumbnail.Path + "/landscape_xlarge." + character.Thumbnail.Extension;

                viewModel.Add(newChar);
            });

            if (name != null)
            {
                ViewBag.SearchName = name;
            }
            if (orderBy != null)
            {
                ViewBag.Order = orderBy;
            }

            ViewBag.Count = characterDataWrapper.Data.Count;
            ViewBag.Limit = characterDataWrapper.Data.Limit;
            ViewBag.Offset = characterDataWrapper.Data.Offset;
            ViewBag.Total = characterDataWrapper.Data.Total;
            ViewBag.Page = page;

            return View(viewModel);
        }

        //GET: Character/Details/id
        public IActionResult Details(int? id, int page = 1)
        {
            if (id == null)
            {
                return NotFound();
            }

            CharacterDataWrapper characterDataWrapper = _marvelRepository.GetCharacter(id.Value);
            SeriesDataWrapper seriesDataWrapper = _marvelRepository.GetRelatedSeries(id.Value, page);

            if (characterDataWrapper == null)
            {
                return NotFound();
            }

            if (seriesDataWrapper == null)
            {
                return NotFound();
            }

            CharacterData viewModel = new CharacterData();

            Character character = characterDataWrapper.Data.Results[0];

            viewModel.ID = character.ID;
            viewModel.Name = character.Name;
            viewModel.Description = character.Description;
            viewModel.Thumbnail = character.Thumbnail.Path + "/portrait_uncanny." + character.Thumbnail.Extension;
            viewModel.Series = new List<SeriesData>();

            seriesDataWrapper.Data.Results.ForEach(series =>
            {
                SeriesData newSeries = new SeriesData();

                newSeries.ID = series.ID;
                newSeries.Title = series.Title;
                newSeries.Thumbnail = series.Thumbnail.Path + "/standard_xlarge." + series.Thumbnail.Extension;

                viewModel.Series.Add(newSeries);
            });

            if (character.URLs.Count >= 2)
                viewModel.WikiLink = character.URLs[1].URL;

            if (character.URLs.Count == 3)
                viewModel.ComicLink = character.URLs[2].URL;

            ViewBag.Count = seriesDataWrapper.Data.Count;
            ViewBag.Limit = seriesDataWrapper.Data.Limit;
            ViewBag.Offset = seriesDataWrapper.Data.Offset;
            ViewBag.Total = seriesDataWrapper.Data.Total;
            ViewBag.Page = page;

            return View(viewModel);
        }
    }
}
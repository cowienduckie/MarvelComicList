using MarvelComicList.ComicAppModels;
using MarvelComicList.MarvelModels;
using MarvelComicList.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MarvelComicList.Controllers
{
    public class SeriesController : Controller
    {
        private readonly IMarvelRepository _marvelRepository;

        // Dependency Injection
        public SeriesController(IMarvelRepository marvelRepo)
        {
            _marvelRepository = marvelRepo;
        }

        // GET: Series
        public IActionResult Index(string title, string orderBy, int startYear = -1, int page = 1)
        {
            SeriesDataWrapper seriesDataWrapper = _marvelRepository.GetSeriesList(title, orderBy, startYear, page);

            if (seriesDataWrapper == null)
            {
                return NotFound();
            }
            List<SeriesData> viewModel = new List<SeriesData>();

            List<Series> series = seriesDataWrapper.Data.Results;

            series.ForEach(seri =>
            {
                SeriesData newSeries = new SeriesData();

                newSeries.ID = seri.ID;
                newSeries.Title = seri.Title;
                newSeries.Description = seri.Description;
                newSeries.StartYear = seri.StartYear;
                newSeries.Type = seri.Type;
                newSeries.Thumbnail = seri.Thumbnail.Path + "/landscape_xlarge." + seri.Thumbnail.Extension;

                viewModel.Add(newSeries);
            });

            if (title != null)
            {
                ViewBag.SearchTitle = title;
            }
            if (orderBy != null)
            {
                ViewBag.Order = orderBy;
            }
            if (startYear != -1)
            {
                ViewBag.SearchYear = startYear;
            }

            ViewBag.Count = seriesDataWrapper.Data.Count;
            ViewBag.Limit = seriesDataWrapper.Data.Limit;
            ViewBag.Offset = seriesDataWrapper.Data.Offset;
            ViewBag.Total = seriesDataWrapper.Data.Total;
            ViewBag.Page = page;

            return View(viewModel);
        }

        //GET: Series/Details/id
        public IActionResult Details(int? id, int page = 1)
        {
            if (id == null)
            {
                return NotFound();
            }

            SeriesDataWrapper seriesDataWrapper = _marvelRepository.GetSeries(id.Value);
            CharacterDataWrapper characterDataWrapper = _marvelRepository.GetRelatedCharacter(id.Value, page);

            if (characterDataWrapper == null)
            {
                return NotFound();
            }

            if (seriesDataWrapper == null)
            {
                return NotFound();
            }

            SeriesData viewModel = new SeriesData();

            Series series = seriesDataWrapper.Data.Results[0];

            viewModel.ID = series.ID;
            viewModel.Title = series.Title;
            viewModel.StartYear = series.StartYear;
            viewModel.Type = series.Type;
            viewModel.Description = series.Description;
            viewModel.Thumbnail = series.Thumbnail.Path + "/portrait_uncanny." + series.Thumbnail.Extension;
            viewModel.Characters = new List<CharacterData>();

            characterDataWrapper.Data.Results.ForEach(character =>
            {
                CharacterData newChar = new CharacterData();

                newChar.ID = character.ID;
                newChar.Name = character.Name;
                newChar.Thumbnail = character.Thumbnail.Path + "/standard_xlarge." + character.Thumbnail.Extension;

                viewModel.Characters.Add(newChar);
            });

            viewModel.DetailLink = series.URLs[0].URL;

            ViewBag.Count = characterDataWrapper.Data.Count;
            ViewBag.Limit = characterDataWrapper.Data.Limit;
            ViewBag.Offset = characterDataWrapper.Data.Offset;
            ViewBag.Total = characterDataWrapper.Data.Total;
            ViewBag.Page = page;

            //Next and previous series

            if (series.Next != null)
            {
                string link = "http://gateway.marvel.com/v1/public/series/";
                int nextID = Convert.ToInt32(series.Next.ResourceURI.Substring(link.Length));

                Series seri = _marvelRepository.GetSeries(nextID).Data.Results[0];

                viewModel.NextSeries = new SeriesData();
                viewModel.NextSeries.ID = seri.ID;
                viewModel.NextSeries.Title = seri.Title;
                viewModel.NextSeries.Thumbnail = seri.Thumbnail.Path + "/standard_xlarge." + seri.Thumbnail.Extension;
            }

            if (series.Previous != null)
            {
                string link = "http://gateway.marvel.com/v1/public/series/";
                int PreviousID = Convert.ToInt32(series.Previous.ResourceURI.Substring(link.Length));

                Series seri = _marvelRepository.GetSeries(PreviousID).Data.Results[0];

                viewModel.PreviousSeries = new SeriesData();
                viewModel.PreviousSeries.ID = seri.ID;
                viewModel.PreviousSeries.Title = seri.Title;
                viewModel.PreviousSeries.Thumbnail = seri.Thumbnail.Path + "/standard_xlarge." + seri.Thumbnail.Extension;
            }

            return View(viewModel);
        }
    }
}
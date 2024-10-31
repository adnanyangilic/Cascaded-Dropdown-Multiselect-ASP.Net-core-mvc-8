using CountriesDB.Data;
using CountriesDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace CountriesDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var countries = _context.Countries.ToList();
            return View(countries);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _context.Countries.ToList();
            return Json(new SelectList(countries, "CountryId", "CountryName"));
        }
        [HttpGet]
        public IActionResult GetStates(int countryId)
        {
            var states = _context.States.Where(x => x.CountryId == countryId).ToList();
            return Json(new SelectList(states, "StateId", "StateName"));
        }
        [HttpGet]
        public IActionResult GetCities(int stateId)
        {
            var cities = _context.Cities.Where(x => x.StateId == stateId).ToList();
            return Json(new SelectList(cities, "CityId", "CityName"));
        }
    }
}


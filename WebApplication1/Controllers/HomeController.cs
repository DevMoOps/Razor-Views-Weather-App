using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeatherList = new List<CityWeather>()
            {
                new CityWeather(){ CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030/01/01 8:00"), TemperatureFahrenheit = 33},
                new CityWeather(){ CityUniqueCode = "NYC", CityName = "London", DateAndTime = DateTime.Parse("2030/01/01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather(){ CityUniqueCode = "PAR", CityName = "Paris", DateAndTime =  DateTime.Parse("2030/01/01 9:00"),  TemperatureFahrenheit = 82},
            };
            
            return View(cityWeatherList);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult City(string? cityCode)
        {
            if (cityCode == null)
            {
                BadRequest("input valid city name");
            }

            List<CityWeather> cityWeatherList = new List<CityWeather>()
            {
                new CityWeather(){ CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030/01/01 8:00"), TemperatureFahrenheit = 33},
                new CityWeather(){ CityUniqueCode = "NYC", CityName = "London", DateAndTime = DateTime.Parse("2030/01/01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather(){ CityUniqueCode = "PAR", CityName = "Paris", DateAndTime =  DateTime.Parse("2030/01/01 9:00"),  TemperatureFahrenheit = 82},
            };

            CityWeather? filter = cityWeatherList.First(item => item.CityUniqueCode == cityCode);
            if(filter == null)
            {
                return Content("city Name does not exist");
            }
            return View(filter);
        }
    }


}

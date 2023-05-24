using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SimpsonsCharacters.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<IActionResult> Index()
        {
            var response = await httpClient.GetAsync("https://api.sampleapis.com/simpsons/characters");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var characters = JsonConvert.DeserializeObject<List<SimpsonCharacter>>(json);
                return View(characters);
            }

            return View();
        }
    }

    public class SimpsonCharacter
    {
        public string Name { get; set; }
        public string genre { get; set; }
    }
}

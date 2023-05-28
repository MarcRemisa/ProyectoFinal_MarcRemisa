﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class HomeController : Controller
{
    private static readonly HttpClient httpClient = new HttpClient();

    public IActionResult Index(string searchTerm)
    {
        const string apiUrl = "https://apisimpsons.fly.dev/api/personajes?limit=649&page=1";

        var client = new HttpClient();
        var response = client.GetAsync(apiUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;

        SimpsonCharacterResponse responseObj = JsonConvert.DeserializeObject<SimpsonCharacterResponse>(content);
        List<SimpsonCharacter> model = responseObj.Docs;

        if (!string.IsNullOrEmpty(searchTerm))
        {
            model = model.FindAll(character => character.Nombre.ToLower().Contains(searchTerm.ToLower()));
        }
        
        return View(model);
    }
}

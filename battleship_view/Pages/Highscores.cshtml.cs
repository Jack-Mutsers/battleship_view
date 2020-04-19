using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Controllers;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace battleship_view
{
    public class HighscoresModel : PageModel
    {
        HighscoreController highscoreController = new HighscoreController();
        PlayerController playerController = new PlayerController();

        public void OnGet()
        {
            var test = highscoreController.GetAll();
            Message = "dit is een test";
            int tests = 1;
        }

    }
}
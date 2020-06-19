using battleship_view.Models;
using Database.Controllers;
using DatabaseEntities.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace battleship_view
{
    public class HighscoresModel : PageModel
    {
        HighscoreController highscoreController = new HighscoreController();

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }

        public ActionResult OnPostAjax([FromBody]Filter filter)
        {
            List<Highscore> result = new List<Highscore>(); 

            if (filter != null)
            {
                if (filter.search != null)
                {
                    result = highscoreController.GetByName(filter.search);
                }
                else if (filter.field != null)
                {
                    result = highscoreController.GetByField(filter.field, filter.direction, filter.highscores);
                }
            }
            else
            {
                result = highscoreController.GetAll();
            }

            return new JsonResult(result);
        }
    }
}
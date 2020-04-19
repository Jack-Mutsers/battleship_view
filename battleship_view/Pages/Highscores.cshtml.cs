using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using battleship_view.Models;
using Database;
//using System.Web.Mvc;
using Database.Controllers;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace battleship_view
{
    public class HighscoresModel : PageModel
    {
        HighscoreController highscoreController = new HighscoreController();

        public void OnGet()
        {

        }

        public JsonResult OnGetHighscores()
        {
            var test = highscoreController.GetAll();
            return new JsonResult(test);
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
                    result = highscoreController.GetByField(filter.field, filter.direction);
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
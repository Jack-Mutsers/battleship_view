using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace battleship_view
{
    public class PlayingFieldModel : PageModel
    {

        public string Coördinate { get; private set; }
        public string Test { get; private set; }
        
        
        public void OnGet()
        {

        }

        public void OnPostShoot()
        {

            Coördinate = Request.Form["button"];
            Test = Request.Form["Test"];

        }

        public static void GetCoordinates(string Id)
        {

        }
            
    }
}
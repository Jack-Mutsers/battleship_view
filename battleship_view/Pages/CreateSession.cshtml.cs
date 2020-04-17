using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace battleship_view
{
    public class CreateSessionModel : PageModel
    {
        public void OnGet()
        {
        SessionCode();

        }

        public void SessionCode()
        {
            int length = 5;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                int val= random.Next(0,2);
                if(val == 0)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    str_build.Append(letter);
                }
                else
                {
                    int newInt = random.Next(0,10);
                    str_build.Append(newInt.ToString());
                }
                
            }
            
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace battleship_view
{
    public class JoinSessionModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        public string Lobbycode { get; set; }

        public List<string> Players = new List<string>();

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Username = Request.Form["Username"];
            Lobbycode = Request.Form["Lobbycode"];
            //send lobbycode and username to the connection class
            //receive the list of players
            //Players = players;
            Players.Add("youri");
            Players.Add("lean");
            Players.Add("martin");
            Players.Add("jack");
            Players.Add("maikel");
            Players.Add("zoe");
        }
    }
}
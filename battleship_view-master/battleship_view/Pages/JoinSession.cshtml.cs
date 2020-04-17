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
        public string Username { get; private set; }
        public string Lobbycode { get; private set; }
        public string Visibility { get; private set; } = "visible";
        public string InverseVisibility { get; private set; } = "invisible";

        public List<string> Players { get; private set; } = new List<string>();

        public void OnGet()
        {

        }

        public void OnPost()
        {
            
            
        }

        public void OnPostJoinLobby()
        {
            Username = Request.Form["Username"];
            Lobbycode = Request.Form["Lobbycode"];

            //send lobbycode and username
            //receive the list of players
            //Players = players;

            Visibility = "invisible";
            InverseVisibility = "visible";

            Players.Add("youri");
            Players.Add("lean");
            Players.Add("martin");
            Players.Add("jack");
            Players.Add("maikel");
            Players.Add("zoe");
        }

        public void OnPostLeaveLobby()
        {
            //remove me from the lobby
            RedirectToPage("/JoinSession");
        }
    }
}
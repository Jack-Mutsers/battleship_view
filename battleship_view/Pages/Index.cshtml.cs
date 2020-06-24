using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleship_view.Logic;
using Entities.Models;
using Entities.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace battleship_view.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {
            if(ServiceBusHandler.program != null)
            {
                if (StaticResources.PlayerList.Count() > 0 && StaticResources.gameCompleted == false)
                {
                    MessageSender messageSender = new MessageSender();
                    messageSender.SendLeaveLobbyMessage();
                }

                TimerHandler.ResetHandler();
                await ServiceBusHandler.ResetData();
            }
            
            StaticResources.ResetData();
        }
    }
}

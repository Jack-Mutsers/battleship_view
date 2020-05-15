﻿using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPlayerRepository
    {
        Player GetPlayerById(int player_Id);
        //Player GetUserWithDetails(string username, string password);
        void CreatePlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Player player);
    }
}

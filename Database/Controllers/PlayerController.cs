﻿using AutoMapper;
using Contracts;
using DatabaseEntities.DatabaseModels;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Database.Controllers
{
    public class PlayerController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PlayerController()
        {
            var config = new MapperConfiguration(cfg => new MappingProfile());
            _mapper = config.CreateMapper();

            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            SqlData sqlData = new SqlData();
            optionsBuilder.UseSqlServer(sqlData.connectionString);

            


            _repository = new RepositoryWrapper(new RepositoryContext(optionsBuilder.Options));
        }

        public Player GetById(int player_id)
        {
            return _repository.player.GetPlayerById(player_id);
        }

        public int CreateNewPlayer(string playerName)
        {
            Player playerData = new Player()
            {
                name = playerName
            };

            _repository.player.CreatePlayer(playerData);
            _repository.Save();

            return playerData.PlayerId;
        }
    }
}

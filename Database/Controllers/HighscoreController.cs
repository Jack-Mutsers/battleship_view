﻿using AutoMapper;
using Contracts;
using DatabaseEntities.DatabaseModels;
using DatabaseEntities.DataTransferObjects;
using Entities;
using Entities.Models;
using Entities.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Database.Controllers
{
    public class HighscoreController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public HighscoreController()
        {
            var config = new MapperConfiguration(cfg => new MappingProfile());
            _mapper = config.CreateMapper();

            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            SqlData sqlData = new SqlData();
            optionsBuilder.UseSqlServer(sqlData.connectionString);

            _repository = new RepositoryWrapper(new RepositoryContext(optionsBuilder.Options));
        }

        public List<Highscore> GetAll()
        {
            var result = _repository.highscore.GetAllHighscores();

            List<Highscore> highscores = _mapper.Map<List<Highscore>>(result);
            return highscores;
        }

        public List<Highscore> GetByField(string field, string direction, List<Highscore> highscores)
        {
            List<Highscore> result = new List<Highscore>();

            if (direction == "asc")
            {
                switch (field)
                {
                    case "shots":
                        result = highscores.OrderBy(pl => pl.shots).ToList();
                        break;
                    case "hits":
                        result = highscores.OrderBy(pl => pl.hits).ToList();
                        break;
                    case "hit_streak":
                        result = highscores.OrderBy(pl => pl.hit_streak).ToList();
                        break;
                }
            }
            else
            {
                switch (field)
                {
                    case "shots":
                        result = highscores.OrderByDescending(pl => pl.shots).ToList();
                        break;
                    case "hits":
                        result = highscores.OrderByDescending(pl => pl.hits).ToList();
                        break;
                    case "hit_streak":
                        result = highscores.OrderByDescending(pl => pl.hit_streak).ToList();
                        break;
                }
            }

            return result;
        }

        public List<Highscore> GetByName(string name)
        {
            var result = _repository.highscore.GetByName(name);

            List<Highscore> highscores = _mapper.Map<List<Highscore>>(result);
            return highscores;
        }

        public void StoreNewHighscoreRecord(HighscoreRecords records) 
        {
            SessionController sessionController = new SessionController();

            Session session = sessionController.FindByCode(StaticResources.sessionCode);

            Highscore highscore = new Highscore()
            {
                PlayerId = StaticResources.user.PlayerId,
                session_id = session.id,
                shots = records.shots,
                hits = records.hits,
                hit_streak = records.highestHitStreak
            };

            _repository.highscore.CreateHighscore(highscore);
            _repository.Save();
        }

        public void Put(Highscore highscore)
        {
            _repository.highscore.UpdateHighscore(highscore);
            _repository.Save();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

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
            optionsBuilder.UseMySql(sqlData.connectionString);

            _repository = new RepositoryWrapper(new RepositoryContext(optionsBuilder.Options));
        }

        public List<Highscore> GetAll()
        {
            var highscores = _repository.highscore.GetAllHighscores();

            return _mapper.Map<List<Highscore>>(highscores);
        }

        public void Post(Highscore highscore) 
        {
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

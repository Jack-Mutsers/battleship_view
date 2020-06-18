using AutoMapper;
using Contracts;
using DatabaseEntities.DatabaseModels;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;

namespace Database.Controllers
{
    public class SessionController
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SessionController()
        {
            var config = new MapperConfiguration(cfg => new MappingProfile());
            _mapper = config.CreateMapper();

            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            SqlData sqlData = new SqlData();
            optionsBuilder.UseSqlServer(sqlData.connectionString);

            _repository = new RepositoryWrapper(new RepositoryContext(optionsBuilder.Options));
        }

        public bool CheckIfSessionExists(string sessionCode)
        {
            _repository.session.CheckForInvalidActiveSessions();
            return _repository.session.ValidateIfActive(sessionCode);
        }

        public void CreateSession(String sessionCode)
        {
            Session session = new Session()
            {
                active = true,
                session_code = sessionCode,
                creation_date = DateTime.Now
            };

            _repository.session.CreateSession(session);
            _repository.Save();
        }

        public void DeleteSession(string sessionCode)
        {
            Session session = _repository.session.GetByCode(sessionCode);

            _repository.session.DeleteSession(session);
            _repository.Save();
        }

        public Session FindByCode(string sessionCode)
        {
            return _repository.session.GetByCode(sessionCode);
        }
    }
}

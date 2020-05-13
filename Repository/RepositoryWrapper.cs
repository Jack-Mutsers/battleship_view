using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IHighscoreRepository _highscore;
        private IPlayerRepository _player;
        private ISessionRepository _session;

        public IHighscoreRepository highscore
        {
            get
            {
                if (_highscore == null)
                {
                    _highscore = new HighscoreRepository(_repoContext);
                }

                return _highscore;
            }
        }

        public IPlayerRepository player
        {
            get
            {
                if (_player == null)
                {
                    _player = new PlayerRepository(_repoContext);
                }

                return _player;
            }
        }


        public ISessionRepository session
        {
            get
            {
                if (_session == null)
                {
                    _session = new SessionRepository(_repoContext);
                }

                return _session;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
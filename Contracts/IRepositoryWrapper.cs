﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        public IHighscoreRepository highscore { get; }
        public IPlayerRepository player { get; }
        public ISessionRepository session { get; }
        void Save();
    }
}

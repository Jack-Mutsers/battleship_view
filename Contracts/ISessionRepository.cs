﻿using DatabaseEntities.DatabaseModels;

namespace Contracts
{
    public interface ISessionRepository
    {
        bool ValidateIfActive(string sessionCode);
        void CheckForInvalidActiveSessions();
        Session GetByCode(string sessionCode);
        void CreateSession(Session session);
        void UpdateSession(Session session);
        void DeleteSession(Session session);
    }
}

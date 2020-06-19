using Contracts;
using DatabaseEntities.DatabaseModels;
using Entities;
using System;
using System.Linq;

namespace Repository
{
    public class SessionRepository : RepositoryBase<Session>, ISessionRepository
    {
        public SessionRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateSession(Session session)
        {
            Create(session);
        }

        public void DeleteSession(Session session)
        {
            session.active = false;
            Update(session);
        }

        public Session GetByCode(string sessionCode)
        {
            return FindByCondition(s => s.session_code == sessionCode).FirstOrDefault();
        }

        public void UpdateSession(Session session)
        {
            Update(session);
        }

        public void CheckForInvalidActiveSessions()
        {
            RawQuery("update session set active = 0 where DATEDIFF(hh, creation_date, GETDATE()) > 5 AND active = 1;");
        }

        public bool ValidateIfActive(string sessionCode)
        {
            DateTime date = DateTime.Now;

            int count = FindByCondition(session => session.active == true && session.creation_date > date.AddDays(-1) && session.session_code == sessionCode).Count();
            return count > 0;
        }
    }
}

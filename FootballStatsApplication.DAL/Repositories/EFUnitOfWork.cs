using FootballStatsApplication.DAL.EF;
using FootballStatsApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private FootballStatsApplicationContext _db;
        private LeagueRepository _leagueRepository;

        public EFUnitOfWork()
        {
            _db = new FootballStatsApplicationContext();
        }
        public IRepository<League> Leagues
        {
            get
            {
                if (_leagueRepository is null)
                {
                    _leagueRepository = new LeagueRepository(_db);
                }
                return _leagueRepository;
            }
        }

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.DisposeAsync();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

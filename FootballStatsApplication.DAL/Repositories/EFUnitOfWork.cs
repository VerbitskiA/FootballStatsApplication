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
        private PlayerRepository _playerRepository;
        private PlaceRepository _placeRepository;
        private MatchRepository _matchRepository;

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

        public IRepository<Player> Players
        {
            get
            {
                if (_playerRepository is null)
                {
                    _playerRepository = new PlayerRepository(_db);
                }
                return _playerRepository;
            }
        }

        public IRepository<Place> Places
        {
            get
            {
                if (_placeRepository is null)
                {
                    _placeRepository = new PlaceRepository(_db);
                }
                return _placeRepository;
            }
        }

        public IRepository<Match> Matches
        {
            get
            {
                if (_matchRepository is null)
                {
                    _matchRepository = new MatchRepository(_db);
                }
                return _matchRepository;
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

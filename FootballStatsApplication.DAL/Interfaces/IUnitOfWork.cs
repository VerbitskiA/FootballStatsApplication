using FootballStatsApplication.DAL.Entities;
using FootballStatsApplication.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ILeagueRepository Leagues { get; }

        IPlayerRepository Players { get; }

        IRepository<Place> Places { get; }

        IRepository<Match> Matches { get; }

        void Save();
    }
}

using FootballStatsApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<League> Leagues { get; }
        void Save();
    }
}

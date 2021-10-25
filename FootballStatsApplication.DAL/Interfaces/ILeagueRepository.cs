using FootballStatsApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.DAL.Interfaces
{
    public interface ILeagueRepository
    {
        IEnumerable<League> GetAll();
        League GetOneById(Guid id);
        League GetOneByLeagueName(string leagueName);
        IEnumerable<League> Find(Func<League, Boolean> predicate);
        void Create(League item);
        void Update(League item);
        void Delete(Guid id);
    }
}

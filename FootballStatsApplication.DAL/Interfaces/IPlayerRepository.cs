using FootballStatsApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.DAL.Repositories
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        Player GetOneById(Guid id);
        IEnumerable<Player> GetPlayersByLeagueName(string leagueName);
        IEnumerable<Player> Find(Func<Player, Boolean> predicate);
        void Create(Player item);
        void Update(Player item);
        void Delete(Guid id);
    }
}
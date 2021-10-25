using FootballStatsApplication.DAL.EF;
using FootballStatsApplication.DAL.Entities;
using FootballStatsApplication.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballStatsApplication.DAL.Repositories
{
    //TODO #1: добавить асинхронность к обращения к БД.
    //https://medium.com/swlh/building-a-nice-multi-layer-net-core-3-api-c68a9ef16368
    class LeagueRepository : ILeagueRepository
    {
        private FootballStatsApplicationContext _db;
        public LeagueRepository(FootballStatsApplicationContext db)
        {
            _db = db;
        }
        public void Create(League item)
        {
            _db.Add(item);
        }

        public void Delete(Guid id)
        {
            League league = _db.Leagues.Find(id);

            if (league != null)
            {
                _db.Leagues.Remove(league);
            }
        }

        public IEnumerable<League> Find(Func<League, bool> predicate)
        {
            return _db.Leagues.Where(predicate);
        }

        public IEnumerable<League> GetAll()
        {
            return _db.Leagues;
        }

        public League GetOneById(Guid id)
        {
            return _db.Leagues.Find(id);
        }

        public League GetOneByLeagueName(string leagueName)
        {
            return _db.Leagues.Where(u => u.LeagueName == leagueName).First();
        }

        public void Update(League item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

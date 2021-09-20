using FootballStatsApplication.DAL.EF;
using FootballStatsApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FootballStatsApplication.DAL.Repositories
{
    public class MatchRepository : IRepository<Match>
    {
        private FootballStatsApplicationContext _db;

        public MatchRepository(FootballStatsApplicationContext db)
        {
            _db = db;
        }

        public void Create(Match item)
        {
            _db.Add(item);
        }

        public void Delete(Guid id)
        {
            Match match = _db.Matches.Find(id);

            if (match != null)
            {
                _db.Matches.Remove(match);
            }
        }

        public IEnumerable<Match> Find(Func<Match, bool> predicate)
        {
           return _db.Matches.Include(a => a.Scores).Where(predicate);
        }

        public IEnumerable<Match> GetAll()
        {
            return _db.Matches.Include(a => a.Scores);
        }

        public Match GetOneById(Guid id)
        {
            return _db.Matches.Find(id);
        }

        public void Update(Match item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

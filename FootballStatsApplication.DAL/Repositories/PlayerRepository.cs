using FootballStatsApplication.DAL.EF;
using FootballStatsApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballStatsApplication.DAL.Repositories
{
    class PlayerRepository : IRepository<Player>
    {
        private FootballStatsApplicationContext _db;

        public PlayerRepository(FootballStatsApplicationContext db)
        {
            _db = db;
        }

        public void Create(Player item)
        {
            _db.Add(item);
        }

        public void Delete(Guid id)
        {
            Player player = _db.Players.Find(id);

            if (player != null)
            {
                _db.Players.Remove(player);
            }
        }

        public IEnumerable<Player> Find(Func<Player, bool> predicate)
        {
            return _db.Players.Where(predicate);
        }

        public IEnumerable<Player> GetAll()
        {
            return _db.Players;
        }

        public Player GetOneById(Guid id)
        {
            return _db.Players.Find(id);
        }

        public void Update(Player item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

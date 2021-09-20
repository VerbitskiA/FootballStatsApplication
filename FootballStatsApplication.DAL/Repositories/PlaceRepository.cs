using FootballStatsApplication.DAL.EF;
using FootballStatsApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballStatsApplication.DAL.Repositories
{
    class PlaceRepository : IRepository<Place>
    {
        private FootballStatsApplicationContext _db;

        public PlaceRepository(FootballStatsApplicationContext db)
        {
            _db = db;
        }

        public void Create(Place item)
        {
            _db.Add(item);
        }

        public void Delete(Guid id)
        {
            Place place = _db.Places.Find(id);

            if (id != null)
            {
                _db.Places.Remove(place);
            }
        }

        public IEnumerable<Place> Find(Func<Place, bool> predicate)
        {
            return _db.Places.Where(predicate);
        }

        public IEnumerable<Place> GetAll()
        {
            return _db.Places;
        }

        public Place GetOneById(Guid id)
        {
            return _db.Places.Find(id);
        }

        public void Update(Place item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

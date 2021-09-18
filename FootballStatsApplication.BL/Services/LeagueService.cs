using AutoMapper;
using FootballStatsApplication.BL.DTO;
using FootballStatsApplication.BL.Interfaces;
using FootballStatsApplication.DAL.EF;
using FootballStatsApplication.DAL.Entities;
using FootballStatsApplication.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.BL.Services
{
    public class LeagueService : ILeagueService
    {
        IUnitOfWork db;
        public LeagueService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<LeagueDTO> GetLeagues()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<League, LeagueDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<League>,IEnumerable<LeagueDTO>>(db.Leagues.GetAll());
        }
    }
}

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

        public void CreateLeague(LeagueDTO leagueDto)
        {            
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<LeagueDTO, League>()).CreateMapper();

            League league = mapper.Map<LeagueDTO,League>(leagueDto);

            db.Leagues.Create(league);
            db.Save();
        }


        public void Dispose()
        {
            db.Dispose();
        }

        public LeagueDTO GetLeagueByName(string leagueName)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<League, LeagueDTO>()).CreateMapper();

            return mapper.Map<League, LeagueDTO>(db.Leagues.GetOneByLeagueName(leagueName));
        }

        public IEnumerable<LeagueDTO> GetLeagues()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<League, LeagueDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<League>,IEnumerable<LeagueDTO>>(db.Leagues.GetAll());
        }
    }
}

using AutoMapper;
using FootballStatsApplication.BL.DTO;
using FootballStatsApplication.BL.Interfaces;
using FootballStatsApplication.DAL.Entities;
using FootballStatsApplication.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.BL.Services
{
    public class PlayerService : IPlayerService
    {
        IUnitOfWork db;

        public PlayerService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public IEnumerable<PlayerDTO> GetPlayersByLeague(string leagueName)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Player, PlayerDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Player>, IEnumerable<PlayerDTO>>(db.Players.GetPlayersByLeagueName(leagueName));
        }

        IEnumerable<PlayerDTO> IPlayerService.GetPlayers()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Player, PlayerDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Player>, IEnumerable<PlayerDTO>>(db.Players.GetAll());
        }

        void IPlayerService.Dispose()
        {
            db.Dispose();
        }

        
    }
}

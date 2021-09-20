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
    public class PlaceService : IPlaceService
    {
        IUnitOfWork db;
        public PlaceService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<PlaceDTO> GetPlaces()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(db.Places.GetAll());
        }
    }
}

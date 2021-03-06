using AutoMapper;
using FootballStatsApplication.BL.DTO;
using FootballStatsApplication.BL.Interfaces;
using FootballStatsApplication.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatsApplication.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        IPlayerService _playerService;

        IPlaceService _placeService;

        public SettingsController(IPlaceService placeService, IPlayerService playerService)
        {
            _playerService = playerService;

            _placeService = placeService;
        }
        public IActionResult GetPlayers()
        {
            IEnumerable<PlayerDTO> playersDTO = _playerService.GetPlayers();

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlayerDTO, PlayerViewModel>()).CreateMapper();

            List<PlayerViewModel> players = mapper.Map<IEnumerable<PlayerDTO>, List<PlayerViewModel>>(playersDTO);

            return View(players);
        }
        public IActionResult GetPlaces()
        {
            IEnumerable<PlaceDTO> placeDTOs = _placeService.GetPlaces();

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, PlacesViewModel>()).CreateMapper();

            List<PlacesViewModel> places = mapper.Map<IEnumerable<PlaceDTO>, List<PlacesViewModel>>(placeDTOs);

            return View(places);
        }
    }
}

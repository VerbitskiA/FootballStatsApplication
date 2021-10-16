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
    public class HomeController : Controller
    {
        ILeagueService _leagueService;

        public HomeController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<LeagueDTO> leagueDTOs = _leagueService.GetLeagues();

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<LeagueDTO, LeagueViewModel>()).CreateMapper();

            List<LeagueViewModel> leagues = mapper.Map<IEnumerable<LeagueDTO>, List<LeagueViewModel>>(leagueDTOs);

            return View(leagues);
        }

        [HttpGet]
        public IActionResult ScoreTable()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PrepareToMatch()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMatch()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Statistics()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Archive()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }
        #region test methods
        [HttpGet]
        public IActionResult CreateLeague()
        {
           return View();
        }

        [HttpPost]
        public IActionResult CreateLeague(string leagueName, string keyword)
        {
            LeagueDTO leagueDTO = new LeagueDTO
            {
                LeagueName = leagueName,
                CreatedOn = DateTime.Now,
                Keyword = keyword
            };

            _leagueService.CreateLeague(leagueDTO);
            
            return RedirectToAction("Index");
        }
        #endregion
    }
}

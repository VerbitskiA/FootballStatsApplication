using AutoMapper;
using FootballStatsApplication.BL.DTO;
using FootballStatsApplication.BL.Interfaces;
using FootballStatsApplication.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FootballStatsApplication.WebUI.Controllers
{
    public class AuthController : Controller
    {
        ILeagueService _leagueService;
        public AuthController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        public IActionResult Index()
        {
            IEnumerable<LeagueDTO> leagueDTOs = _leagueService.GetLeagues();

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<LeagueDTO, LeagueViewModel>()).CreateMapper();

            List<LeagueViewModel> leagues = mapper.Map<IEnumerable<LeagueDTO>, List<LeagueViewModel>>(leagueDTOs);

            return View(leagues);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string leagueName)
        {            
            await Authenticate(leagueName);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string leagueName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, leagueName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Auth");
        }
    }
}

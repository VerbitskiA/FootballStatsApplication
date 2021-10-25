using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatsApplication.WebUI.Models
{
    public class CreatePlayerModel
    {
        public Guid LeagueId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Avatar { get; set; }
        public string FootStyle { get; set; }
    }
}

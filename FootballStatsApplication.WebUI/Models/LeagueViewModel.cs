using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatsApplication.WebUI.Models
{
    public class LeagueViewModel
    {
        public Guid Id { get; set; }

        public string LeagueName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Keyword { get; set; }
    }
}

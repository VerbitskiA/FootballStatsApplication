using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.BL.DTO
{
    public class LeagueDTO
    {
        public Guid Id { get; set; }

        public string LeagueName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Keyword { get; set; }
    }
}

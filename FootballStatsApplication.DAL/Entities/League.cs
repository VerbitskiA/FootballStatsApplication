using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.DAL.Entities
{
    class League
    {
        public Guid Id { get; set; }

        public string LeagueName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Keyword { get; set; }
    }
}

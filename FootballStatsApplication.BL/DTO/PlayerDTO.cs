using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.BL.DTO
{
    public class PlayerDTO
    {
        public Guid Id { get; set; }
        public Guid LeagueId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Avatar { get; set; }
        public string FootStyle { get; set; }
    }
}

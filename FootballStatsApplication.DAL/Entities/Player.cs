using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.DAL.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Avatar { get; set; }
        public string FootStyle { get; set; }
    }
}

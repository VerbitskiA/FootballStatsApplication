using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FootballStatsApplication.DAL.Entities
{
    class Match
    {
        public Guid Id { get; set; }
        public Guid PlaceId { get; set; }

        [ForeignKey("PlaceId")]
        public Place Place { get; set; }
        public DateTime PlayedOn { get; set; }
        public Guid ResultId { get; set; }
        
        [ForeignKey("ResultId")]
        public Result Result { get; set; }
        public int AutogoalsTeamRed { get; set; }
        public int AutogoalsTeamBlue { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FootballStatsApplication.DAL.Entities
{
    public class Score
    {
        public Guid Id { get; set; }
        public Guid MatchId { get; set; }
        
        [ForeignKey("MatchId")]
        public Match Match { get; set; }
        public Guid PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public Player Player { get; set; }
        public Guid TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public float Distance { get; set; }        
    }
}

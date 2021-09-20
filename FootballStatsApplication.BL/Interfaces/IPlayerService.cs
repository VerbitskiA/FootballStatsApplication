using FootballStatsApplication.BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.BL.Interfaces
{
    public interface IPlayerService
    {
        IEnumerable<PlayerDTO> GetPlayers();
        void Dispose();
    }
}

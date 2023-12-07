using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vijuge.Data.Models.DTOs;

namespace Vijuge.Data.Repositories.Interface
{
    public interface IPlayerRepository
    {
        Task<PlayerDTO> GetPlayersById(int id);
        Task<PlayerDTO> GetPlayerByUserId(int id);
        Task<IEnumerable<PlayerDTO>> GetAllPlayers();
        Task<IEnumerable<PlayerDTO>> GetAllOnlinePlayers();
        Task<IEnumerable<PlayerDTO>> GetAllFreePlayers();
        Task SetPlayerAsLoggedIn(int playerId);
    }
}

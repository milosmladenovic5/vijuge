using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vijuge.Data.Models.DTOs;
using Vijuge.Data.Repositories.Interface;

namespace Vijuge.Data.Repositories.Implementation
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly VijugeDbContext _context;

        public PlayerRepository(VijugeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerDTO>> GetAllFreePlayers()
        {
            return _context.Players.Where(p => p.LoggedIn && !p.Playing).ToList();
        }

        public Task<IEnumerable<PlayerDTO>> GetAllOnlinePlayers()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlayerDTO>> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDTO> GetPlayerByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDTO> GetPlayersById(int id)
        {
            throw new NotImplementedException();
        }

        public Task SetPlayerAsLoggedIn(int playerId)
        {
            throw new NotImplementedException();
        }
    }
}

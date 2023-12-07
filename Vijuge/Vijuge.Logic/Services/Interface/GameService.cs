using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vijuge.Data.Repositories.Interface;
using Vijuge.Logic.Services.Implementation;

namespace Vijuge.Logic.Services.Interface
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper, IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        public async Task StartWaitingForOponent(int userId)
        {
            var currentPlayer = _playerRepository.GetPlayerByUserId(userId);
            var freePlayers = _playerRepository.GetAllFreePlayers();


            /* TODO
             * 1. Fetch appropriate player from player repository
             * 2. Set that the player is logged in
             * 3. Check with bacgkrounds service for pairing players
             * 4. Find player with similar ranking that is logged in (online)
             * 5. Return value that indicates waiting started to player, so that frontend can switch to that state             
             */
        }
    } 
}

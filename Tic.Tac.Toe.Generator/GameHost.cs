using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tic.Tac.Toe.Generator.Services;

namespace Tic.Tac.Toe.Generator
{
    public class GameHost
    {
        IGameService _gameService {get;set;}
        public GameHost(IGameService gameService)
        {
            _gameService = gameService;
        }
        public void Run()
        {
            _gameService.DisplayGrid();
        }
    }
}
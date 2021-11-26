using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tic.Tac.Toe.Board;
using Tic.Tac.Toe.Generator.Services;

namespace Tic.Tac.Toe.Generator
{
    public class GameService : IGameService
    {

        IBoardService _boardService {get;set;}
       public GameService(BoardService boardService)
       {
           _boardService = boardService;
           Initialize();
       }

        public void DisplayGrid()
        {
            _boardService.DisplayGrid();
        }

        private void Initialize()
        {
            _boardService.CreateBoard();
        }

        
    }
}
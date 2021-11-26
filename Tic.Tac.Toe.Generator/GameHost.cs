using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tic.Tac.Toe.Generator.Players;
using Tic.Tac.Toe.Generator.Services;

namespace Tic.Tac.Toe.Generator
{
    public class Host
    {
        IBoardService _boardService {get;set;}
        IPlayerService _playerOne {get;set;}
        IPlayerService _playerTwo {get;set;}
        bool GameInProgress;


        public Host(IBoardService boardService, IPlayerService playerOne, IPlayerService playerTwo)
        {
            _boardService = boardService;
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }
        public void Run()
        {
            try
            {
            _boardService.CreateBoard();
            _boardService.DisplayGrid();
            Console.Clear();
            

            Menu();

            if(GameInProgress)
                SetPlayers();
          

            while(GameInProgress)
            {
               
                PlayerOneTurn();
                _boardService.DisplayGrid();
                Console.Clear();
                PlayerTwoTurn();
                _boardService.DisplayGrid();
                return;


                Console.ReadLine();
            }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Something Went Wrong.");
            }
            
        }

        public void SetPlayers()
        {
            System.Console.WriteLine("Player One: x");
            System.Console.WriteLine("Player Two: o");
            _playerOne.SetMarker('x');
            _playerTwo.SetMarker('o');
        }

        public void PlayerOneTurn()
        {
            int[] coordinates;

            System.Console.WriteLine("Player One's Turn!");
            System.Console.WriteLine("__________________");
            System.Console.WriteLine();
            coordinates = FillGridSpot();

            var success = _boardService.AssignPosition(coordinates[0], coordinates[1], _playerOne.marker);
            while(!success)
            {    Console.Clear();
                coordinates = FillGridSpot();
                success = _boardService.AssignPosition(coordinates[0], coordinates[1], _playerOne.marker);
            }
        }

         public void PlayerTwoTurn()
        {
            int[] coordinates;

            System.Console.WriteLine("Player Two's Turn!");
            System.Console.WriteLine("__________________");
            System.Console.WriteLine();
            coordinates = FillGridSpot();

            var success = _boardService.AssignPosition(coordinates[0], coordinates[1], _playerTwo.marker);
            while(!success)
                Console.Clear();
                coordinates = FillGridSpot();
                success = _boardService.AssignPosition(coordinates[0], coordinates[1], _playerTwo.marker);
        }

        public int[] FillGridSpot()
        {
            System.Console.WriteLine("Enter (x, y) coordinates to place marker in spot on grid.");
            System.Console.WriteLine("x  - coordinate: ");
            int x = int.Parse(System.Console.ReadLine());
            System.Console.Clear();
            System.Console.WriteLine("y  - coordinate:");
            int y = int.Parse(System.Console.ReadLine());
            return new int[]{x,y};
        }

        public void Menu()
        {
            System.Console.WriteLine("Tic Tac Toe");
            System.Console.WriteLine("___________");
            System.Console.WriteLine("Continue y/n?");
            var input = Console.ReadLine().ToString();
            if(input == "y")
            {
                GameInProgress =  true;  
                return;
            }
            GameInProgress =  false;
        }
    }
}
using System.Runtime.CompilerServices;
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
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Something Went Wrong");
                System.Console.WriteLine("Restart ?");
                if(Console.ReadLine() == "y")
                    Run();
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
             
            string[] coordinates; bool success;

            System.Console.WriteLine("Player One's Turn!");
            System.Console.WriteLine("__________________");
            System.Console.WriteLine();
            coordinates = FillGridSpot();

            
            var validInput = ValidateInput(coordinates[0], coordinates[1]);
            while(!validInput)
            {   
                coordinates = FillGridSpot();
                validInput = ValidateInput(coordinates[0], coordinates[1]);
            }

            success = _boardService.AssignPosition(int.Parse(coordinates[0]), int.Parse(coordinates[1]), _playerOne.marker);
            while(!success)
            {    
                coordinates = FillGridSpot();
                success = _boardService.AssignPosition(int.Parse(coordinates[0]), int.Parse(coordinates[1]), _playerOne.marker);
            }
        }

        public void PlayerTwoTurn()
        {
            string[] coordinates; bool success;

            System.Console.WriteLine("Player Two's Turn!");
            System.Console.WriteLine("__________________");
            System.Console.WriteLine();
            coordinates = FillGridSpot();

           var validInput = ValidateInput(coordinates[0], coordinates[1]);
            while(!validInput)
            {   
                coordinates = FillGridSpot();
                validInput = ValidateInput(coordinates[0], coordinates[1]);
            }

            success = _boardService.AssignPosition(int.Parse(coordinates[0]), int.Parse(coordinates[1]), _playerTwo.marker);
            while(!success)
            {   
                coordinates = FillGridSpot();
                success = _boardService.AssignPosition(int.Parse(coordinates[0]), int.Parse(coordinates[1]), _playerTwo.marker);

            }
        }

        public string[] FillGridSpot()
        {
            System.Console.WriteLine("Enter (x, y) coordinates to place marker in spot on grid.");
            System.Console.WriteLine("x  - coordinate: ");
            string x =System.Console.ReadLine();
            System.Console.Clear();
            System.Console.WriteLine("y  - coordinate:");
            string y =System.Console.ReadLine();
            return new string[]{x,y};
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

        public bool ValidateInput(string x, string y)
        {
            if(!int.TryParse(x, out int xResult) || !int.TryParse(y,out int yResult))
            { System.Console.WriteLine("Invalid input!");  return false;}

            return true;
        }   

        IBoardService _boardService {get;set;}
        IPlayerService _playerOne {get;set;}
        IPlayerService _playerTwo {get;set;}
        bool GameInProgress; 
    }
}
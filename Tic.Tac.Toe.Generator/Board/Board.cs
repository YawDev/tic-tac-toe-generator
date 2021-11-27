using System.Linq;
using System;
using System.Text;
using Tic.Tac.Toe.Generator.Services;
using System.Threading.Tasks;

namespace Tic.Tac.Toe.Board
{
    public class BoardService : IBoardService
    {
        private char[,] board { get; set; } = new char[3,3];
        
        public char[,] CreateBoard()
        {
            var stringBuilder = new StringBuilder();
              for(int row=0;row<3;row++)
              {  
                for(int column=0;column<3;column++)
                {
                    board[row,column] = '_';
                    stringBuilder.Append(board[row,column]).Append(" "); 
                }
                stringBuilder.Append("\n").Append("\n");
                }

            return board;
        }

        public void DisplayGrid()
        {
            for(int row=0;row<3;row++)
            {  
                for(int column=0;column<3;column++)
                {
                    System.Console.Write(board[row, column]+ " | ");
                }
                System.Console.WriteLine();
            }
        }

        public bool AssignPosition(int x, int y, char marker)
        {
            if(board[x,y] == '_')
            {    
                board[x,y] = marker; 
                return true;
            }
            System.Console.WriteLine("Spot is already taken.");
            return false;
        }

        public bool CheckForWinner()
        {
           if(HorizontalWin())
                return true;

            if(VerticalWin())
                return true;
            
            if(DiagonalWin())
                return true;

            return false;
        }

        public bool HorizontalWin()
        {
            if((board[0,0] == board[0,1] &&  board[0,1] == board[0,2]) && board[0,0] != '_')
                return true;

            if((board[1,0] == board[1,1] &&  board[1,1] == board[1,2]) && board[1,0] != '_')
                return true;

            if((board[2,0] == board[2,1] &&  board[2,1] == board[2,2]) && board[2,0] != '_')
                return true;

            return false;
        }

        public bool VerticalWin()
        {
            if((board[0,0] == board[1,0] &&  board[1,0] == board[2,0]) && board[0,0] != '_')
                return true;

            if((board[0,1] == board[1,1] &&  board[1,1] == board[2,1]) && board[0,1] != '_')
                return true;

            if((board[0,2] == board[1,2] &&  board[1,2] == board[2,2]) && board[2,2] != '_')
                return true;

            return false;
        }

        public bool DiagonalWin()
        {
            if((board[0,0] == board[1,1] &&  board[1,1] == board[2,2]) && board[0,0] != '_')
                return true;

            if((board[0,2] == board[1,1] &&  board[1,1] == board[2,0]) && board[0,2] != '_')
                return true;

            return false;
        }

        
    }
}

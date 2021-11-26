using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic.Tac.Toe.Generator.Services
{
    public interface IBoardService
    {
        char[,] CreateBoard();
        void DisplayGrid();
        bool AssignPosition(int x,int y, char marker);
    }
}
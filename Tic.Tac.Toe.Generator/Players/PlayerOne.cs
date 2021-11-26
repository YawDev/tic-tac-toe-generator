using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic.Tac.Toe.Generator.Players
{
    public class PlayerOne : IPlayerService
    {
       
        public string nameDefault {get;set; } = "PlayerOne";
        public char marker {get;set;}

        public void SetMarker(char choice)
        {
            marker = choice;
        }
    }
}
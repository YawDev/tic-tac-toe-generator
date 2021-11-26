using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic.Tac.Toe.Generator.Players
{
    public class PlayerTwo : IPlayerService
    {
        public PlayerTwo()
        {
            nameDefault = "PlayerTwo";
        }

        public string nameDefault { get; set; }
        public char marker { get; set; }

        public void SetMarker(char choice)
        {
           marker = choice;
        }
    }
}
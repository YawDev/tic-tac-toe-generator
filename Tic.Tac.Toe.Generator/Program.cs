using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tic.Tac.Toe.Board;
using Tic.Tac.Toe.Generator.Players;
using Tic.Tac.Toe.Generator.Services;

namespace Tic.Tac.Toe.Generator
{
    public class Program
    {

        public static void Main(string[] args)
        {
            
           InitializeHost();
           host.Run();
        }

        public static void InitializeHost()
        {
            CreateSingleton();
        }

        public static void CreateSingleton()
        {
            var instances = new object[]{new BoardService(), new PlayerOne(), new PlayerTwo()};
            host = new Host((IBoardService)instances[0], (IPlayerService)instances[1], (IPlayerService)instances[2]);
        }

        public static Host host { get; set; }

        

      
        
    }
}
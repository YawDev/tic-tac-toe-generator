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
        public static GameService _gameService { get; set; }
        
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var host = new GameHost(_gameService);
        }

         public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IGameService, GameService>();
                    services.AddSingleton<IBoardService, BoardService>();
                    services.AddSingleton<IPlayerService, PlayerOne>();
                    services.AddSingleton<IPlayerService, PlayerTwo>();
                });

      
        
    }
}
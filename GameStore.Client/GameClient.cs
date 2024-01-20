using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Client.Models;

namespace GameStore.Client
{
    public static class GameClient
    {
        private static readonly List<Game> games = new(){
    new Game(){
     Id= 1,
     Name = "Street Fighter",
     Genre = "Fighting",
     Price = 19.99M,
     ReleasedDate = new DateTime(2000,2,1)
    },  new Game(){
     Id= 2,
     Name = "Final Fantasy",
     Genre = "Playing",
     Price = 29.99M,
     ReleasedDate = new DateTime(2007,7,16)
    },  new Game(){
     Id= 3,
     Name = "Fifa",
     Genre = "Soccer",
     Price = 49.99M,
     ReleasedDate = new DateTime(2020,4,12)
    }
   };

        public static Game[] GetGames()
        {
            return games.ToArray();
        }

        public static void AddGame(Game game)
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);
        }
        public static Game GetGame(int id)
        {
            return games.Find(game => game.Id == id) ?? throw new Exception("Could not find the game!");
        }

        public static void UpdateGame(Game updatedGame)
        {
            Game existingGame = GetGame(updatedGame.Id);
            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleasedDate = updatedGame.ReleasedDate;
        }

        public static void DeleteGame(int id)
        {
            Game existingGame = GetGame(id);
games.Remove(existingGame);
        }
    }
}
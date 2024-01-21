using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Client.Models;
//for retrieving Json Data from Web API and Sending Data Back
using System.Net.Http.Json;

namespace GameStore.Client
{

    //make remote request
    public class GameClient
    {
        private readonly HttpClient httpClient;
        //indepedency injection
        public GameClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        //Invoke GET METHOD on the Web API
        //Returns A Task - allow to return a null 
        public async Task<Game[]?> GetGamesAsync()
        {
            //<> - What type of Class should the Data be converted to when being retrieved
            //Also specify the URL you are Invoking
            return await httpClient.GetFromJsonAsync<Game[]>("games");
        }

        //Allow method to return Task from the Server
        public async Task AddGameAsync(Game game)
        {
            //Specify the Resource the POST METHOD will be utilizing and the data
            await httpClient.PostAsJsonAsync("games", game);
            // game.Id = games.Max(game => game.Id) + 1;
            // games.Add(game); 
        }
        public async Task<Game> GetGameAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<Game>($"games/{id}") ?? throw new Exception("Could not find the game!");
            // return games.Find(game => game.Id == id) ?? throw new Exception("Could not find the game!");
        }

        public async Task UpdateGameAsync(Game updatedGame)
        {

            await httpClient.PutAsJsonAsync<Game>($"games/{updatedGame.Id}", updatedGame);
            // Game existingGame = GetGame(updatedGame.Id);
            // existingGame.Name = updatedGame.Name;
            // existingGame.Genre = updatedGame.Genre;
            // existingGame.Price = updatedGame.Price;
            // existingGame.ReleasedDate = updatedGame.ReleasedDate;
        }

        public async Task DeleteGameAsync(int id)

        {
            await httpClient.DeleteAsync($"games/{id}");
            // Game existingGame = GetGame(id);
            // games.Remove(existingGame);
        }
    }
}
using MongoDB.Driver;
using MongoDbLib.Interfaces;
using MongoDbLib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbLib.Services
{
    public class GameService
    {
        private readonly IMongoCollection<Game> _games;

        public GameService(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _games = database.GetCollection<Game>(settings.CollectionName);
        }

        public async Task<IEnumerable<Game>> Get() => (await _games.FindAsync(game => true)).ToEnumerable();

        public async Task<Game> Get(string id) => (await _games.FindAsync(game => game.Id == id)).FirstOrDefault();

        public async Task<Game> Create(Game game)
        {
            await _games.InsertOneAsync(game);
            return game;
        }

        public async Task Update(string id, Game updatedGame) => await _games.ReplaceOneAsync(game => game.Id == id, updatedGame);

        public async Task Delete(Game gameForDeletion) => await _games.DeleteOneAsync(game => game.Id == gameForDeletion.Id);

        public async Task Delete(string id) => await _games.DeleteOneAsync(game => game.Id == id);
    }
}

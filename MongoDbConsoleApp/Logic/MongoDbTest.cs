using MongoDbLib.Services;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MongoDbConsoleApp.Logic
{
    public class MongoDbTest : IDisposable
    {
        private readonly GameService _gameService;
        private bool disposedValue;

        public MongoDbTest(GameService gamesService)
        {
            _gameService = gamesService;
        }

        public async Task TestConnection()
        {
            Console.WriteLine("Games:");
            var gameList = await _gameService.Get();
            var game = await _gameService.Get("619ad9446f0d4a27c7d73ea9");
            var gamesJson = JsonSerializer.Serialize(gameList);
            Console.WriteLine(gamesJson);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MongoDbTest()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

using System.Threading.Tasks;
using Configurations;
using Core;
using Platform;

namespace Services
{
    public class SpawnerService : Service<GameSpawnerConfiguration>
    {
        public override Task InitializeServiceAsync()
        {
            Engine.GetService<GameplayService>().StartGameEvent += OnStartGame;
            return Task.CompletedTask;
        }

        public override void ResetService()
        {
        }

        public override void DestroyService()
        {
        }

        private void OnStartGame()
        {
            Engine.Instantiate(Configuration.PlayerPrefab);
            Engine.Instantiate(Configuration.AsteroidsSpawnerPrefab);
        }
    }
}
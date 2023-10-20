using System;
using System.Threading.Tasks;
using Core;
using Platform;

namespace Services
{
    public class GameplayService : Service
    {
        public event Action StartGameEvent;
        public event Action EndGameEvent;
        
        public override Task InitializeServiceAsync()
        {
            Engine.GetService<SceneService>().SceneLoadedEvent += OnSceneLoaded;
            return Task.CompletedTask;
        }

        public override void ResetService()
        {
        }

        public override void DestroyService()
        {
        }

        private void OnSceneLoaded()
        {
            StartGameEvent?.Invoke();
        }
    }
}
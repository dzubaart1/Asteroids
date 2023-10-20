using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platform
{
    public class SceneService : Service
    {
        public Action SceneLoadedEvent;
        public Action SceneUnLoadedEvent;
        public Action SceneChangedEvent;

        public int CurrentScene { get; private set; }

        public override Task InitializeServiceAsync()
        {
            return Task.CompletedTask;
        }

        public override void ResetService()
        {
        }

        public override void DestroyService()
        {
        }

        public void LoadScene(int sceneIndex)
        {
            var op = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
            op.completed += OnSceneLoaded;
            
            UpdateScene(sceneIndex);
        }

        public void UnloadScene(int sceneIndex)
        {
            var op = SceneManager.UnloadSceneAsync(sceneIndex);
            op.completed += OnSceneUnloaded;
            
            UpdateScene(sceneIndex);
        }

        private void UpdateScene(int sceneIndex)
        {
            CurrentScene = sceneIndex;
        }

        private void OnSceneLoaded(AsyncOperation op)
        {
            op.completed -= OnSceneLoaded;

            SceneLoadedEvent?.Invoke();
            SceneChangedEvent?.Invoke();
        }

        private void OnSceneUnloaded(AsyncOperation op)
        {
            op.completed -= OnSceneUnloaded;

            SceneUnLoadedEvent?.Invoke();
            SceneChangedEvent?.Invoke();
        }
    }
}

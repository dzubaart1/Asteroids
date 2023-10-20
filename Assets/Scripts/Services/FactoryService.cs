using System.Threading.Tasks;
using Configurations;
using Platform;
using Spawners;
using UnityEngine;

namespace Services
{
    public class FactoryService : Service<FactoryConfiguration>
    {
        public IAbstractFactory CurrentFactory { get; private set; }
        
        public override Task InitializeServiceAsync()
        {
            CurrentFactory = new EasyModeFactory();
            return Task.CompletedTask;
        }

        public void ChangeFactory(IAbstractFactory newFactory)
        {
            CurrentFactory = newFactory;
        }

        public override void ResetService()
        {
        }

        public override void DestroyService()
        {
        }

        public Sprite GetRandomAsteroidSprite()
        {
            var list = Configuration.AsteroidsSpritesList;
            return list[Random.Range(0, list.Count-1)];
        }
    }
}
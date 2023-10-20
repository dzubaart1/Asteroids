using System.Collections.Generic;
using Platform;
using UnityEngine;

namespace Configurations
{
    public class FactoryConfiguration : Configuration
    {
        public List<Sprite> AsteroidsSpritesList;
        public Sprite BulletSprite;
        public GameObject BulletPrefab;
        public GameObject AsteroidPrefab;
    }
}
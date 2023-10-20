using Asteroids;
using Bullets;
using Core;
using Services;
using UnityEngine;

namespace Spawners
{
    public class HardModeFactory : IAbstractFactory
    {
        public BaseAsteroid SpawnAsteroid()
        {
            var asteroid = Object.Instantiate(Engine.GetService<FactoryService>().Configuration.AsteroidPrefab);
            var res = asteroid.AddComponent<HardModeAsteroid>();
            asteroid.GetComponent<SpriteRenderer>().sprite =
                Engine.GetService<FactoryService>().GetRandomAsteroidSprite();
            asteroid.GetComponent<SpriteRenderer>().color = Color.red;
            asteroid.GetComponent<Rigidbody2D>().angularDrag = 0;
            asteroid.GetComponent<Rigidbody2D>().gravityScale = 0;
            return res;
        }

        public BaseBullet SpawnBullet()
        {
            var bullet = Object.Instantiate(Engine.GetService<FactoryService>().Configuration.BulletPrefab);
            var res = bullet.AddComponent<HardModeBullet>();
            bullet.GetComponent<SpriteRenderer>().sprite =
                Engine.GetService<FactoryService>().Configuration.BulletSprite;
            bullet.GetComponent<SpriteRenderer>().color = Color.red;
            bullet.GetComponent<Rigidbody2D>().angularDrag = 0;
            bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            return res;
        }
    }
}
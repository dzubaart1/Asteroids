using Asteroids;
using Bullets;

namespace Spawners
{
    public interface IAbstractFactory
    {
        public BaseAsteroid SpawnAsteroid();
        public BaseBullet SpawnBullet();
    }
}
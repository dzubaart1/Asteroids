using System.Collections;
using Core;
using Services;
using UnityEngine;

namespace DefaultNamespace
{
    public class AsteroidsSpawner : MonoBehaviour
    {
        private bool _isSpawn;
        private const float SPAWN_AREA = 13f;
        
        private void Start()
        {
            StartSpawn();
            StartCoroutine(SpawnAsteroids());
        }

        public void StartSpawn()
        {
            _isSpawn = true;
        }

        public void StopSpawn()
        {
            _isSpawn = false;
        }

        private IEnumerator SpawnAsteroids()
        {
            if (!_isSpawn)
            {
                yield break;
            }

            var asteroid = Engine.GetService<FactoryService>().CurrentFactory.SpawnAsteroid();
            asteroid.transform.position = Random.insideUnitCircle.normalized * SPAWN_AREA;
            asteroid.GetComponent<Rigidbody2D>().AddForce(-Random.insideUnitCircle * SPAWN_AREA * 30f);

            yield return new WaitForSeconds(0.2f);
            StartCoroutine(SpawnAsteroids());
        }
    }
}
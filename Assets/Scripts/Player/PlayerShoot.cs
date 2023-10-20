using Bullets;
using Core;
using Services;
using UnityEngine;

namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        
        private void Awake()
        {
            Engine.GetService<InputService>().ShootEvent += OnShoot;
        }

        private void OnDestroy()
        {
            Engine.GetService<InputService>().ShootEvent -= OnShoot;
        }

        private void OnShoot()
        {
            var bullet = Engine.GetService<FactoryService>().CurrentFactory.SpawnBullet();
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up *_bulletSpeed);
        }
    }
}
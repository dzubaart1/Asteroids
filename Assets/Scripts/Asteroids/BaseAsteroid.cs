using System;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public abstract class BaseAsteroid : MonoBehaviour
    {
        private const float MAX_LIFE_TIME = 30f;
        
        private float _currentHP;

        private void Awake()
        {
            _currentHP = InitMaxHP();
        }

        private void Start()
        {
            Destroy(gameObject, MAX_LIFE_TIME);
        }

        public abstract float InitMaxHP();

        public void TakeDamage(float damage)
        {
            _currentHP -= damage;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}
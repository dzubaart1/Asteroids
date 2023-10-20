using System;
using Core;
using Services;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _turnSpeed = 3f;
        [SerializeField] private float _runSpeed = 3f;
        
        private Rigidbody2D _rigidbody;
    
        private Vector2 _direction;
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
            Engine.GetService<InputService>().RunEvent += OnRun;
        }

        private void OnDestroy()
        {
            Engine.GetService<InputService>().RunEvent -= OnRun;
        }

        private void FixedUpdate()
        {
            if (_direction.x != 0)
            {
                _rigidbody.AddTorque(-1 * _direction.x * _turnSpeed);
                _direction.x = 0;
            }
            if (_direction.y != 0)
            {
                _rigidbody.AddForce(Mathf.Sign(_direction.y) * transform.up * _runSpeed);
                _direction.y = 0;
            }
        }

        private void OnRun(Vector2 direction)
        {
            _direction = direction;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Asteroid"))
            {
                
            }
        }
    }
}
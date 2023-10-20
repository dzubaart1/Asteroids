using UnityEngine;

namespace Bullets
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public abstract class BaseBullet : MonoBehaviour
    {
        private const float MAX_LIFE_TIME = 3f;
        private void Start()
        {
            Destroy(gameObject, MAX_LIFE_TIME);
        }

        public abstract float DealDamage();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Boundary"))
            {
                Destroy(gameObject);
            }
        }
    }
}
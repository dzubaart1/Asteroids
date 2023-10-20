namespace Bullets
{
    public class HardModeBullet : BaseBullet
    {
        private const float DAMAGE = 10f;
        
        public override float DealDamage()
        {
            return DAMAGE;
        }
    }
}
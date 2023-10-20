namespace Bullets
{
    public class EasyModeBullet : BaseBullet
    {
        private const float DAMAGE = 20f;
        
        public override float DealDamage()
        {
            return DAMAGE;
        }
    }
}
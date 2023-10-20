namespace Asteroids
{
    public class EasyModeAsteroid : BaseAsteroid
    {
        private const float HP = 20f;
        
        public override float InitMaxHP()
        {
            return HP;
        }
    }
}
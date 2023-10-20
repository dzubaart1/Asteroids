namespace Asteroids
{
    public class HardModeAsteroid : BaseAsteroid
    {
        private const float HP = 40f;
        
        public override float InitMaxHP()
        {
            return HP;
        }
    }
}
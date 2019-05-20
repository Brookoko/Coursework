namespace Script.HitBox
{
    public interface IAlive
    {
        void GetDamage(int damage);
        bool IsAlive();
        void Death();
        bool IsVulnerable();
        int Health();
    }
}
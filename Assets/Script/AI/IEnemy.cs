namespace Script.AI
{
    public interface IEnemy
    {
        bool IsEntityVisible();
        void Reaction();
        void Move(float move);
        bool IsHitWall();
    }
}
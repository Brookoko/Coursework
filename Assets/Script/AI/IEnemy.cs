using Script.AI.Reaction;
using Script.MoveControllers;

namespace Script.AI
{
    public interface IEnemy : IFreezable, IEntityReaction, IMovable
    {
        bool IsHitWall();
        bool IsOnGround();
    }
}
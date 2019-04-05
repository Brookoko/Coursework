using UnityEngine;

namespace Script.AI
{
    public interface IEntityReaction
    {
        bool IsEntityVisible(Transform entity);
        void Reaction(Transform entity);
    }
}
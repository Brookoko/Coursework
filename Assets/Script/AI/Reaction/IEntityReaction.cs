using UnityEngine;

namespace Script.AI.Reaction
{
    public interface IEntityReaction
    {
        Transform Entity { get; set; }
        bool IsEntityVisible();
        void Reaction();
    }
}
using UnityEngine;

namespace Script.HitBox
{
    public interface IAttack
    {
        float Damage(GameObject target);
    }
}
using UnityEngine;

namespace Script.HitBox
{
    public interface IAttack
    {
        int Damage(GameObject target);
    }
}
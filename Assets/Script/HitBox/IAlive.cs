using UnityEngine;

namespace Script.HitBox
{
    public interface IAlive
    {
        void GetDamage(float damage);
        bool IsAlive();
        void Death();
        bool IsVulnerable();
    }
}
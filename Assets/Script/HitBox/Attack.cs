using UnityEngine;

namespace Script.HitBox
{
    public class Attack : MonoBehaviour, IAttack
    {
        [SerializeField] private float damage = 1;

        public virtual float Damage(GameObject target)
        {
            return damage;
        }
    }
}
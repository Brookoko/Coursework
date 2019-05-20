using UnityEngine;

namespace Script.HitBox
{
    public class Attack : MonoBehaviour, IAttack
    {
        [SerializeField] private int damage = 1;

        public virtual int Damage(GameObject target) => damage;
    }
}
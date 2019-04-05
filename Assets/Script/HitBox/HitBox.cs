using System.Linq;
using UnityEngine;

namespace Script.HitBox
{
    [RequireComponent(typeof(IAlive), typeof(IAttack))]
    public class HitBox : MonoBehaviour
    {
        [SerializeField] private string[] vulnerableTo;
        [SerializeField] private IAlive status;
        [SerializeField] private IAttack attack;

        private void Start()
        {
            status = GetComponent<IAlive>();
            attack = GetComponent<IAttack>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var entityHitBox = GetHitBox(other);
            if (!entityHitBox) return;
            if (status.IsVulnerable())
                status.GetDamage(entityHitBox.Attack(transform.parent.gameObject));
            if (!status.IsAlive())
                status.OnDeath();
        }

        private float Attack(GameObject entity)
        {
            return attack.Damage(entity);
        }

        private HitBox GetHitBox(Collider2D col)
        {
            var entityHitBox = col.GetComponent<HitBox>();
            return vulnerableTo.Any(col.CompareTag) ? entityHitBox : null;
        }
    }
}
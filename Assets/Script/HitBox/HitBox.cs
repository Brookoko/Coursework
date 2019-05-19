using System.Linq;
using Script.SaveLoad;
using UnityEngine;
using UnityEngine.Events;

namespace Script.HitBox
{
    [RequireComponent(typeof(IAlive), typeof(IAttack))]
    public class HitBox : MonoBehaviour
    {
        [SerializeField] private string[] vulnerableTo;
        [SerializeField] private IAlive status;
        [SerializeField] private IAttack attack;
        [SerializeField] private IntEvent OnTrigger;
        
        private void Awake()
        {
            status = GetComponent<IAlive>();
            attack = GetComponent<IAttack>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var entityHitBox = GetHitBox(other);
            if (!entityHitBox) return;
            var pos = other.transform.position.x - transform.parent.position.x;
            OnTrigger.Invoke(pos > 0 ? 1 : -1);
            if (status.IsVulnerable())
                status.GetDamage(entityHitBox.Attack(transform.parent.gameObject));
            if (!status.IsAlive())
                status.Death();
        }

        private int Attack(GameObject entity) => attack?.Damage(entity) ?? 0;

        private HitBox GetHitBox(Collider2D col)
        {
            var entityHitBox = col.GetComponent<HitBox>();
            return vulnerableTo.Any(col.CompareTag) ? entityHitBox : null;
        }
    }
}
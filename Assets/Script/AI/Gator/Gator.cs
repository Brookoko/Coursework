using UnityEngine;

namespace Script.AI.Gator
{
    public class Gator : BasicEnemy
    {
        [SerializeField] private float timeBtwAttack;
        [SerializeField] private GameObject fireball;
        [Space]
        [SerializeField] private LayerMask whatIsBarrier;
        [SerializeField] private Transform wallChecker;
        [SerializeField] private float distance = 1;
        
        private float attackTimer;
        private bool wasInDeadZone;
     
        private RaycastHit2D[] cols = new RaycastHit2D[1];
 
        private void Awake()
        {
            attackTimer = timeBtwAttack;
        }

        private void Update()
        {
            attackTimer -= Time.deltaTime;
        }

        public void Move()
        {
            base.Move(transform.position.x - player.position.x);
        }

        public override void Reaction()
        {
            Attack();
            base.Reaction();
        }

        public override bool IsHitWall()
        {
            var col = Physics2D.RaycastNonAlloc(wallChecker.position, transform.forward*-1, cols, distance, whatIsBarrier);
            
            return col > 0;
        }

        private void Attack()
        {
            if (attackTimer > 0) return;
            attackTimer = timeBtwAttack;
            var offset = transform.localScale.x < 0 ? -1.5f : 1.5f;
            Instantiate(fireball, transform.position + Vector3.right * offset, Quaternion.identity, transform);
        }
    }
}
using UnityEngine;

namespace Script.AI.Gator
{
    public class Gator : BasicEnemy
    {
        [SerializeField] private float timeBtwAttack;
        [SerializeField] private GameObject fireball;
        [Space]
        [SerializeField] private float deadZone;
        [SerializeField] private float timeInDeadZoneToReact;
        [Space]
        [SerializeField] private LayerMask whatIsBarrier;
        [SerializeField] private Transform wallChecker;
        [SerializeField] private float distance = 1;
        
        private RaycastHit2D[] cols = new RaycastHit2D[1];
        
        private float attackTimer;
        private bool wasInDeadZone;
        private float deadZoneTimer;
        private Rigidbody2D rb;
        
        private void Awake()
        {
            attackTimer = timeBtwAttack;
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            attackTimer -= Time.deltaTime;
            deadZoneTimer -= Time.deltaTime;
        }

        public void Move()
        {
            base.Move(transform.position.x - player.position.x);
        }

        public override bool IsEntityVisible()
        {
            return base.IsEntityVisible() && IsOnDeadZone();
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
        
        private bool IsOnDeadZone()
        {
            var visible = Mathf.Abs(transform.position.x - player.position.x) > deadZone;
            
            if (!visible)
            {
                if (!wasInDeadZone)
                {
                    wasInDeadZone = true;
                    deadZoneTimer = timeInDeadZoneToReact;
                }
                else if (deadZoneTimer < 0) DeadZoneCheck();
            }
            else
            {
                if (wasInDeadZone) Attack();
                else wasInDeadZone = false;
                deadZoneTimer = timeInDeadZoneToReact;
            }
            
            return visible;
        }

        private void DeadZoneCheck()
        {
            var x = transform.position.x - player.position.x > 0 ? 1 : -1;

            if (IsHitWall() && x * transform.localScale.x * -1 > 0) x = 0;

            var target = transform.position + Vector3.right * x * deadZone * 10;
            
            rb.MovePosition(Vector2.MoveTowards(transform.position, target, Time.deltaTime * deadZone * 2));
        }
    }
}
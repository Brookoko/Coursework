using UnityEngine;

namespace Script.AI.Hopper
{
    public class Hopper : BasicEnemy
    {
        [SerializeField] private LayerMask whatIsBarrier;
        [SerializeField] private Transform wallCheckerFront;
        [SerializeField] private Transform wallCheckerBack;
        [SerializeField] private float distance = 1f;
        
        private RaycastHit2D[] cols = new RaycastHit2D[2];
        private Rigidbody2D rb;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public override bool IsHitWall()
        {
            return IsHitWallFront() || IsHitWallBack();
        }

        private bool IsHitWallFront()
        {
            var col =
                Physics2D.RaycastNonAlloc(wallCheckerFront.position, transform.forward, cols, distance, whatIsBarrier);
            
            return col > 0;
        }

        private bool IsHitWallBack()
        {
            var col =
                Physics2D.RaycastNonAlloc(wallCheckerBack.position, transform.forward*-1, cols, distance, whatIsBarrier);
            
            return col > 0;
        }

        public override void Move(float move)
        {
            if (Mathf.Abs(rb.velocity.y) > 0.01)
                return;
               
            if (IsEntityVisible())
                move = (player.position.x - transform.position.x > 0 ? 1 : -1) * Time.deltaTime;
            else if (IsHitWallFront() && transform.forward.x * move > 0)
                move *= -1;
            else if (IsHitWallBack() && transform.forward.x * move < 0)
                move *= -1;
                
            base.Move(move);
        }
    }
}
using UnityEngine;

namespace Script.AI.Ant
{
    public class Ant : BasicEnemy
    {
        [SerializeField] private LayerMask whatIsBarrier;
        [SerializeField] private Transform wallChecker;
        [SerializeField] private float distance = 1;
        [SerializeField] private Transform groundChecker;
        [SerializeField] private float radius = 0.2f;
        
        private RaycastHit2D[] cols = new RaycastHit2D[1];
        private bool frozen;
        
        public override bool IsHitWall()
        {
            var col = Physics2D.RaycastNonAlloc(wallChecker.position, Vector2.right  * transform.localScale.x, cols, distance, whatIsBarrier);
            
            return col > 0;
        }

        public override bool IsOnGround()
        {
            var col = Physics2D.RaycastNonAlloc(groundChecker.position, Vector2.down, cols, radius, whatIsBarrier);
            
            return col > 0;
        }

        public override bool IsEntityVisible() => !frozen && base.IsEntityVisible();

        public override void Toggle()
        {
            frozen = !frozen;
        }

        public override bool IsFrozen() => frozen;
    }
}
using UnityEngine;

namespace Script.AI.Ant
{
    public class Ant : BasicEnemy
    {
        [SerializeField] private LayerMask whatIsBarrier;
        [SerializeField] private Transform wallChecker;
        [SerializeField] private float distance = 1;
        
        private RaycastHit2D[] cols = new RaycastHit2D[1];
        
        public override bool IsHitWall()
        {
            var col = Physics2D.RaycastNonAlloc(wallChecker.position, Vector2.right  * transform.localScale.x, cols, distance, whatIsBarrier);
            
            return col > 0;
        }
    }
}
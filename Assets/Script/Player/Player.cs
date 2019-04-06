using Script.MoveControllers;
using UnityEngine;

namespace Script.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform ceilingCheck;
        [SerializeField] private float radius = .2f;
        [SerializeField] private LayerMask whatIsGround;
        
        private Collider2D[] cols = new Collider2D[1];
        private IMoveController controller;

        private void Awake()
        {
            controller = GetComponent<IMoveController>();
        }

        public bool IsOnGround()
        {
            var col = Physics2D.OverlapCircleNonAlloc(groundCheck.position, radius, cols, whatIsGround);
            return col > 0;
        }

        public bool IsHitCeil()
        {
            var col = Physics2D.OverlapCircleNonAlloc(ceilingCheck.position, radius, cols, whatIsGround);
            return col > 0;
        }

        public void Move(float move)
        {
            controller.Move(move);
        }
    }
}
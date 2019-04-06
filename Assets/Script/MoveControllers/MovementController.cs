using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.MoveControllers
{
    public class MovementController : MonoBehaviour, IMoveController {
        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
        public float speed = 20f;
    
        private Vector2 vel = Vector2.zero;
        private bool facingRight = true;
        private Rigidbody2D rb;
    
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Move(float move)
        {
            Vector3 targetVelocity = new Vector2(move * speed * 10f, rb.velocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref vel, movementSmoothing);
        
            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();
        }
    
        private void Flip()
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
        }
    }
}

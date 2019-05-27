using UnityEngine;

namespace Script.MoveControllers
{
    public class MovementController : MonoBehaviour, IMoveController {
        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
        [SerializeField] private float speed = 20f;
    
        private Vector2 vel = Vector2.zero;
        private bool facingRight = true;
        private Rigidbody2D rb;
    
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            if (transform.localScale.x < 0) facingRight = false;
        }

        public void Move(float move)
        {
            Vector3 targetVelocity = new Vector2(move * speed * 10f, rb.velocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref vel, movementSmoothing);
        
            if (move > 0 && !facingRight || move < 0 && facingRight) Flip();
        }
    
        private void Flip()
        {
            facingRight = !facingRight;
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}

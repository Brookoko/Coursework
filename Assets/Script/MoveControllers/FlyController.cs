using UnityEngine;

namespace Script.MoveControllers
{
    public class FlyController : MonoBehaviour, IMoveController {
        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float verticalSpeed;
        [SerializeField] private float radius;
        
        private bool facingRight = true;
        private Vector2 vec = Vector2.zero;
        private Rigidbody2D rb;
    
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            if (transform.localScale.x < 0) facingRight = false;
        }

        public void Move(float move)
        {
            float time = Time.time;
            Vector2 vel = new Vector2(Mathf.Cos(time) * horizontalSpeed, Mathf.Sin(time) * verticalSpeed) * radius / 10f;
            rb.velocity = Vector2.SmoothDamp(rb.velocity, vel, ref vec, movementSmoothing);
            if (move < 0 && !facingRight || move > 0 && facingRight) Flip();
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

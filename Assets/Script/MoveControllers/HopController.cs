using UnityEngine;

namespace Script.MoveControllers
{
    public class HopController : MonoBehaviour, MoveController
    {
        [SerializeField] private float jumpHeight;
        [SerializeField] private float jumpLength;
        
        private bool facingRight = true;
        private Rigidbody2D rb;
        private Vector2 vel;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Move(float move) {
            rb.AddForce(new Vector2(GetX() * move * 10f, GetY()), ForceMode2D.Impulse);
            if (move > 0 && !facingRight || move < 0 && facingRight)
                Flip();
        }

        private float GetX()
        {
            return Mathf.Sqrt(jumpLength * jumpLength * -Physics2D.gravity.y / (2 * jumpHeight));
        }

        private float GetY()
        {
            return Mathf.Sqrt(2 * jumpHeight * -Physics2D.gravity.y);
        }

        private void Flip()
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180f, 0);
        }
    }
}
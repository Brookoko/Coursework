using UnityEngine;

namespace Script.Player
{
    public class PlayerAttack : HitBox.Attack
    {
        [SerializeField] private float bounceForce;
        
        private Transform player;
        private Rigidbody2D rb;
        
        private void Awake()
        {
            player = transform.parent;
            rb = player.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            transform.position = player.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            rb.velocity = new Vector2(rb.velocity.x, bounceForce);
        }
    }
}
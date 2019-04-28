using Script.HitBox;
using Script.StateMachineUtil;
using UnityEngine;

namespace Script.Player
{
    public class DashAttack : Attack
    {
        [SerializeField] private Vector2 pushBackForce;
        
        private Transform player;
        private Rigidbody2D rb;
        private StateMachine sm;
    
        private void Awake()
        {
            player = transform.parent;
            rb = player.GetComponent<Rigidbody2D>();
            sm = player.GetComponentInChildren<StateMachine>();
        }

        private void Update()
        {
            transform.position = player.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            sm.ResetStates();
            float direction = Mathf.Lerp(-1, 1, player.transform.position.x - other.transform.position.x);
            Vector2 force = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Acos(direction), Vector2.up) * pushBackForce;
            int y = player.transform.position.y > other.transform.position.y ? 1 : -1;
            force = new Vector2(force.x, force.y * y);
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
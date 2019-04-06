using Script.StateMachineUtil;
using UnityEngine;

namespace Script.Player.StateInput
{
    public class JumpInputHandler : MonoBehaviour, IInputHandler
    {
        [SerializeField] private int jumpNumber = 2;

        private int currentJumpNumber;
        private StateMachine sm;
        private Rigidbody2D rb;
        private Vector3 vel = Vector3.zero;

        private void Awake()
        {
            var player = GameObject.FindWithTag("Player");
            rb = player.GetComponent<Rigidbody2D>();
            sm = transform.parent.GetComponent<StateMachine>();
            currentJumpNumber = jumpNumber;
        }

        public bool ValidateInput()
        {
            if (Mathf.Abs(rb.velocity.y) > 0.01f && currentJumpNumber == jumpNumber) currentJumpNumber--;
            return currentJumpNumber-- > 0;
        }
        
        public void Handle()
        {
            if (Input.GetButtonDown("Jump") && currentJumpNumber > 0)
                sm.ChangeState("Jump");

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
                rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector2.zero, ref vel, .03f);
            
            if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
        }
        
        public void ResetJumps()
        {
            if (rb.velocity.y > 0) return;
            currentJumpNumber = jumpNumber;
            sm.ChangeState("Idle");
        }
    }
}
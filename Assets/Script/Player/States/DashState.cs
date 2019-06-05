using UnityEngine;
using Input = UnityEngine.Input;

namespace Script.Player.States
{
    public class DashState : BasePlayerState
    {
        [SerializeField] private float dashVelocity = 100;
        [SerializeField] private float dashTime = 1f;
        [SerializeField] private GameObject attackHitBox;

        private float timer;
        private float gravity;
        private float movement;
        private bool stop;
        
        public override string Name { get; } = "Dash";

        public override bool Enter()
        {
            if (!input.ValidateInput()) return false;
            Instantiate(attackHitBox, player.transform);
            timer = dashTime;
            gravity = rb.gravityScale;
            rb.gravityScale = 0;
            DashVelocity();
            stop = false;
            return base.Enter();
        }

        private void Update()
        {
            if (timer < -0.2f) sm.ChangeState("Fall");
            else if (timer < 0 && !stop)
            {
                stop = true;
                rb.velocity = Vector2.zero;
            }
            movement = Input.GetAxisRaw("Horizontal");
            timer -= Time.deltaTime;
        }

        private void FixedUpdate()
        {
            if (timer < 0) player.Move(movement * Time.fixedDeltaTime);
        }

        private void DashVelocity()
        {
            rb.velocity = Vector2.zero;
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(x) < 0.01 && Mathf.Abs(y) < 0.01) x = player.transform.localScale.x;
            Flip(x);
            rb.AddForce(new Vector2(x, y).normalized * dashVelocity, ForceMode2D.Impulse);
        }
        
        private void Flip(float x)
        {
            player.Move(x * 0.000001f);
        }

        public override void Exit()
        {
            rb.gravityScale = gravity;
            rb.velocity = Vector2.zero;
            base.Exit();
        }
    }
}
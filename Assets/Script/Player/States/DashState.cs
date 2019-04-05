using UnityEngine;

namespace Script.Player.States
{
    public class DashState : BasePlayerState
    {
        [SerializeField] private float dashVelocity = 100;
        [SerializeField] private int dashNumber = 1;
        [SerializeField] private float dashTime = 1f;
        [SerializeField] private GameObject attackHitBox;

        private static int currentDashNumber;
        private float timer;
        private Transform hitbox;
        private float gravity;

        public override string Name { get; } = "Dash";

        private void Start()
        {
            currentDashNumber = dashNumber - 1;
        }

        private void ResetDash()
        {
            currentDashNumber = dashNumber;
        }
        
        public override bool Enter()
        {
            if (currentDashNumber <= 0) return false;
            base.Enter();
            if (hitbox) Destroy(hitbox.gameObject);
            hitbox = Instantiate(attackHitBox, player.transform).transform;
            timer = dashTime;
            currentDashNumber--;
            ChangeGravity();
            DashVelocity();
            animator.SetBool("isDashing", true);
            effect.Play();
            return base.Enter();
        }

        private void Update()
        {
            if (timer < -0.2f)
                sm.ChangeState("Fall");
            else if (timer < 0)
                rb.velocity = Vector2.zero;

            timer -= Time.deltaTime;
            hitbox.position = player.transform.position;
        }
        
        private void ChangeGravity()
        {
            var g = rb.gravityScale;
            rb.gravityScale = gravity;
            gravity = g;
        }
        
        private void DashVelocity()
        {
            rb.velocity = Vector2.zero;
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            Flip(x);
            if (Mathf.Abs(x) < 0.01 && Mathf.Abs(y) < 0.01) x = player.transform.localRotation.y < 0 ? -1 : 1;
            rb.AddForce(new Vector2(x, y).normalized * dashVelocity, ForceMode2D.Impulse);
        }
        
        private void Flip(float x)
        {
            controller.Move(x * 0.01f);
        }

        public override void Exit()
        {
            animator.SetBool("isDashing", false);           
            ChangeGravity();
            if (hitbox) Destroy(hitbox.gameObject);
            if (IsOnGround()) ResetDash();
            effect.Stop();
            base.Exit();
        }
    }
}
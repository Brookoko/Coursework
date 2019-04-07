using Script.Player.StateInput;
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
        private Transform hitbox;
        private float gravity;
        
        public override string Name { get; } = "Dash";

        public override bool Enter()
        {
            if (!input.ValidateInput()) return false;
            if (hitbox) Destroy(hitbox.gameObject);
            hitbox = Instantiate(attackHitBox, player.transform).transform;
            timer = dashTime;
            ChangeGravity();
            DashVelocity();
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
            player.Move(x * 0.000001f);
        }

        public override void Exit()
        {
            ChangeGravity();
            if (hitbox) Destroy(hitbox.gameObject);
            base.Exit();
        }
    }
}
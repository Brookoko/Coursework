using UnityEngine;

namespace Script.AI.Ant
{
    public class MoveState : BaseEntityState
    {
        [SerializeField] private float moveDuration;

        private float timer;
        private float movement;

        public override string Name { get; } = "Move";

        public override bool Enter()
        {
            anim.SetBool("Movement", true);
            SetDirection();
            return base.Enter();
        }

        private void Update()
        {
            if (timer < 0) SetDirection();
            else timer -= Time.deltaTime;
            
            if (enemy.IsHitWall()) SetDirection();
            if (enemy.IsEntityVisible()) sm.ChangeState("Rage");
        }

        private void FixedUpdate()
        {
            enemy.Move(movement * Time.fixedDeltaTime);
        }

        public override void Exit()
        {
            anim.SetBool("Movement", false);
            base.Exit();
        }

        private void SetDirection()
        {
            if (Random.Range(0, 7) == 0) sm.ChangeState("Idle");
            movement = enemy.IsHitWall() ? entity.localScale.x * -1 : Random.Range(0, 2) == 0 ? -1 : 1;
            timer = Random.Range(moveDuration - 2f, moveDuration + 2f);
        }
    }
}
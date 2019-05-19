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
            SetDirection(false);
            return base.Enter();
        }

        private void Update()
        {
            if (timer < 0) SetDirection(true);
            else if (enemy.IsHitWall()) SetDirection(false);
            else if (!enemy.IsOnGround()) SetDirection(true);
            else if (enemy.IsEntityVisible() && enemy.IsOnGround()) sm.ChangeState("Rage");
            timer -= Time.deltaTime;
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

        private void SetDirection(bool canTransiteToIdle)
        {
            if (Random.Range(0, 7) == 0 && canTransiteToIdle) sm.ChangeState("Idle");
            else
            {
                movement = enemy.IsHitWall() || !enemy.IsOnGround() ?
                    entity.localScale.x * -1 : Random.Range(0, 2) == 0 ? -1 : 1;
                timer = Random.Range(moveDuration - 2f, moveDuration + 2f);     
            }
        }
    }
}
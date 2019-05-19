using UnityEngine;

namespace Script.AI.Ant
{
    public class IdleState : BaseEntityState
    {
        [SerializeField] private float timeToWait;

        private float timer;

        public override string Name { get; } = "Idle";

        public override bool Enter()
        {
            anim.SetBool("Movement", false);
            timer = Random.Range(timeToWait, timeToWait + 1f);
            return base.Enter();
        }

        private void Update()
        {
            if (!enemy.IsFrozen() && timer < 0) sm.ChangeState("Move");
            else if (enemy.IsEntityVisible() && enemy.IsOnGround()) sm.ChangeState("Rage");
            timer -= Time.deltaTime;
        }

        private void FixedUpdate()
        {
            enemy.Move(0);
        }
    }
}
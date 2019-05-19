using UnityEngine;

namespace Script.AI.Ant
{
    public class RageState : BaseEntityState
    {
        [SerializeField] private float rageTime = 0.2f;
        
        private float timer;

        public override string Name { get; } = "Rage";

        public override bool Enter()
        {
            timer = rageTime;
            anim.SetBool("Rage", true);
            return base.Enter();
        }

        private void Update()
        {
            if (timer < 0) sm.ChangeState("Idle");
            else if (enemy.IsHitWall()) sm.ChangeState("Idle");
            else if (!enemy.IsOnGround()) sm.ChangeState("Idle");
            else if (enemy.IsEntityVisible()) enemy.Reaction();
            else timer -= Time.deltaTime;
        }

        public override void Exit()
        {
            anim.SetBool("Rage", false);
            base.Exit();
        }
    }
}
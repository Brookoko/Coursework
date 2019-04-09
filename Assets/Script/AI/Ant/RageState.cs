using UnityEngine;

namespace Script.AI.Ant
{
    public class RageState : BaseEntityState
    {
        [SerializeField] private float rageTime;
        
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
            if (entity.IsEntityVisible()) entity.Reaction();
            if (!entity.IsEntityVisible() && timer < 0 || entity.IsHitWall()) sm.ResetStates();
            timer -= Time.deltaTime;
        }

        public override void Exit()
        {
            anim.SetBool("Rage", false);
            base.Exit();
        }
    }
}
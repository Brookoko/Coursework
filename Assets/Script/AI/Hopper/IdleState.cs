using UnityEngine;

namespace Script.AI.Hopper
{
    public class IdleState : BaseEntityState
    {
        [SerializeField] private float timeBtwJumps;

        private float timer;
        
        public override string Name { get; } = "Idle";

        public override bool Enter()
        {
            timer = timeBtwJumps;
            return base.Enter();
        }

        private void Update()
        {
            if (!enemy.IsFrozen() && (timer <= 0 || enemy.IsEntityVisible())) sm.ChangeState("Jump");
            timer -= Time.deltaTime;
        }
    }
}
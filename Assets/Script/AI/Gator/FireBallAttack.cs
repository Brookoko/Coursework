using UnityEngine;

namespace Script.AI.Gator
{
    public class FireBallAttack : HitBox.Attack
    {
        public override int Damage(GameObject target)
        {
            transform.GetComponent<FireBall>().OnCollide();
            return base.Damage(target);
        }
    }
}
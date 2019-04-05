using System.Collections;
using Script.HitBox;
using Script.StateMachineUtil;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Player
{
    public class PlayerAlive : BaseAlive
    {
        [SerializeField] private Vector2 pushBackForce = new Vector2(12, 4);
        
        private Transform player;
        private Animator anim;
        private Rigidbody2D rb;
        private float gravity;
        private StateMachine sm;
        
        private void Start()
        {
            player = transform.parent;
            anim = player.GetComponent<Animator>();
            rb = player.GetComponent<Rigidbody2D>();
            sm = player.GetComponentInChildren<StateMachine>();
        }

        public override void GetDamage(float damage)
        {
            base.GetDamage(damage);
            StartCoroutine(OnDamage());
        }

        private IEnumerator OnDamage()
        {
            Input.Disable();
            ToggleObjects();
            ResetAnimation();
            ChangeGravity();
            rb.velocity = Vector2.zero;
            anim.SetTrigger("Hurt");
            yield return new WaitForSeconds(0.5f);
            ChangeGravity();
            rb.AddForce(pushBackForce, ForceMode2D.Impulse);
            StartCoroutine(Blinking());
            ToggleObjects();
            yield return new WaitForSeconds(0.2f);
            Input.Enable();
        }

        private static void ToggleObjects()
        {
            foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                Rigidbody2D rbObj = obj.GetComponent<Rigidbody2D>();
                Animator animObj = obj.GetComponent<Animator>();
                if (!rbObj || !animObj) continue;
                animObj.enabled = !animObj.enabled;
                rbObj.simulated = !rbObj.simulated;
            }
        }

        private void ResetAnimation()
        {
            foreach (var par in anim.parameters)
            {
                if (par.type == AnimatorControllerParameterType.Int)
                    anim.SetInteger(par.name, par.defaultInt);
                else if (par.type == AnimatorControllerParameterType.Float)
                    anim.SetFloat(par.name, par.defaultFloat);
                else if (par.type == AnimatorControllerParameterType.Bool)
                    anim.SetBool(par.name, par.defaultBool);
                else if (par.type == AnimatorControllerParameterType.Trigger)
                    anim.ResetTrigger(par.name);
            }
            sm.ResetStates();
        }

        private void ChangeGravity()
        {
            var g = rb.gravityScale;
            rb.gravityScale = gravity;
            gravity = g;
        }
    }
}
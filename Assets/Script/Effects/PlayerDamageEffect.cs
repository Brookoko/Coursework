using System.Collections;
using Script.StateMachineUtil;
using UnityEngine;
using UnityEngine.SceneManagement;
using Input = Script.Player.StateInput.Input;

namespace Script.Effects
{
    public class PlayerDamageEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private Vector2 pushBackForce = new Vector2(12, 4);
        
        private Transform player;
        private Animator anim;
        private Rigidbody2D rb;
        private Collider2D col;
        private float gravity;
        private StateMachine sm;
        private Coroutine cor;

        private void Awake()
        {
            player = transform.parent;
            anim = player.GetComponent<Animator>();
            rb = player.GetComponent<Rigidbody2D>();
            sm = player.GetComponentInChildren<StateMachine>();
            col = GetComponent<Collider2D>();
        }

        public void Play()
        {
            StartCoroutine(OnDamage());
        }

        public void Stop() {}

        private IEnumerator OnDamage()
        {
            Input.Disable();
            ToggleObjects();
            ToggleHitbox();
            ResetAnimation();
            ChangeGravity();
            rb.velocity = Vector2.zero;
            anim.SetTrigger("Hurt");
            yield return new WaitForSeconds(0.5f);
            ChangeGravity();
            rb.AddForce(pushBackForce, ForceMode2D.Impulse);
            ToggleObjects();
            ToggleHitbox();
            yield return new WaitForSeconds(0.2f);
            Input.Enable();
        }

        private static void ToggleObjects()
        {
            foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                Rigidbody2D rbObj = obj.GetComponent<Rigidbody2D>();
                Animator animObj = obj.GetComponent<Animator>();
                if (rbObj) rbObj.simulated = !rbObj.simulated;
                if (animObj) animObj.enabled = !animObj.enabled;
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

        public void ToggleHitbox()
        {
            col.enabled = !col.enabled;
        }
    }
}
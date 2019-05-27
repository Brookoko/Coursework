using UnityEngine;

namespace Script.Effects
{
    public class DeathEffect : MonoBehaviour, IEffect
    {
        private Transform entity;
        private Animator anim;

        private void Awake()
        {
            entity = transform.parent;
            anim = GetComponent<Animator>();
            gameObject.SetActive(false);
            anim.enabled = false;
        }

        public void Play()
        {
            transform.SetParent(null);
            transform.position = entity.position;
            gameObject.SetActive(true);
            anim.enabled = true;
        }

        public void Stop()
        {
            Destroy(gameObject);
        }
    }
}
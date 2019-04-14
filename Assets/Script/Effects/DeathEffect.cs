using UnityEngine;

namespace Script.Effects
{
    public class DeathEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private GameObject effect;
        
        private Transform entity;

        private void Awake()
        {
            entity = transform.parent;
        }

        public void Play()
        {
            Instantiate(effect, entity.position, Quaternion.identity);
        }

        public void Stop()
        {
            Destroy(gameObject);
        }
    }
}
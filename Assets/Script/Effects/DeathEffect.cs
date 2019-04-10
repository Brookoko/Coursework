using UnityEngine;

namespace Script.Effects
{
    public class DeathEffect : MonoBehaviour, IEffect
    {
        public void Play()
        {
            Instantiate(gameObject, transform.position, Quaternion.identity);
        }

        public void Stop()
        {
            Destroy(gameObject);
        }
    }
}
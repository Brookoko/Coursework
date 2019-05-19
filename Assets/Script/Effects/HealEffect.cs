using UnityEngine;

namespace Script.Effects
{
    public class HealEffect : MonoBehaviour, IEffect
    {
        public void Play()
        {
            gameObject.SetActive(true);
        }

        public void Stop()
        {
            gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Script
{
    public class TimeSlow : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnSlow;
        
        public void Stop(float speed)
        {
            StartCoroutine(Slow(speed));
        }

        private IEnumerator Slow(float speed)
        {
            while (Time.timeScale > 0)
            {
                if (Time.timeScale - speed < 0) break;
                Time.timeScale -= speed;
                Time.fixedDeltaTime -= speed;
                yield return null;
            }
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
            OnSlow.Invoke();
        }

        public void ResetTime()
        {
            StopAllCoroutines();
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
    }
}
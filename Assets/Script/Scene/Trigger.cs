using UnityEngine;
using UnityEngine.Events;

namespace Script.Scene
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnTriggerEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OnTriggerEvent.Invoke();
            }
        }
    }   
}

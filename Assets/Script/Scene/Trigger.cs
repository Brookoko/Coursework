using UnityEngine;
using UnityEngine.Events;

namespace Script.Scene
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private string tag = "Player";
        [SerializeField] private UnityEvent OnTriggerEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(tag))
            {
                OnTriggerEvent.Invoke();
            }
        }
    }   
}

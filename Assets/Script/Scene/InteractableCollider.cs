using UnityEngine;
using UnityEngine.Events;

namespace Script.Scene
{
    public class InteractableCollider : MonoBehaviour
    {
        [SerializeField] private string tag = "Player";
        [SerializeField] private UnityEvent OnTriggerEvent;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(tag))
            {
                OnTriggerEvent.Invoke();
            }
        }
    }
}
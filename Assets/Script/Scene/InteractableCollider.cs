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
            Debug.Log(gameObject.name);
            Debug.Log(other.gameObject.tag + ":" + other.gameObject.name);
            if (other.gameObject.CompareTag(tag))
            {
                OnTriggerEvent.Invoke();
            }
        }
    }
}
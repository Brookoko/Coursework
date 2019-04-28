using UnityEngine;

namespace Script.Scene
{
    public class Trigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SceneTransition.Load(SceneIndexToLoad);
            }
        }
    }   
}

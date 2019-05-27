using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class ClearOnDestroy : MonoBehaviour
    {
        [SerializeField] private GameObject curtain;
        
        public void Clear(GameObject onDontDestroyObject)
        {
            Instantiate(curtain);
            if (onDontDestroyObject == null) onDontDestroyObject = GameObject.FindWithTag("Player");
            if (onDontDestroyObject == null) return;
            foreach (GameObject obj in onDontDestroyObject.scene.GetRootGameObjects())
            {
                Destroy(obj);
            }
        }
    }
}
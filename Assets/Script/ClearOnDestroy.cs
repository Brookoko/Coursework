using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class ClearOnDestroy : MonoBehaviour
    {
        [SerializeField] private GameObject curtain;
        
        public void Clear(GameObject onDontDestroyObject)
        {
            if (curtain) Instantiate(curtain);
            if (!onDontDestroyObject) return;
            foreach (GameObject obj in onDontDestroyObject.scene.GetRootGameObjects())
            {
                Destroy(obj);
            }
        }

        public void Clear(Object obj)
        {
            Clear(GameObject.FindWithTag("Player"));
        }
    }
}
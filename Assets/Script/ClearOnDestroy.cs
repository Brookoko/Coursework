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
            foreach (GameObject obj in onDontDestroyObject.scene.GetRootGameObjects())
            {
                Destroy(obj);
            }
        }
    }
}
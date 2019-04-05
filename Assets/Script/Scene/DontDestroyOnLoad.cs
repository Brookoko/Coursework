using UnityEngine;

namespace Script.Scene
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
            
            if (objs.Length > 1)
                Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject);
        }
    }
}
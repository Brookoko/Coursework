using UnityEngine;

namespace Script
{
    public class DestroyEvent : MonoBehaviour
    {
        public void Destroy()
        {
            GameObject obj = GameObject.FindGameObjectWithTag(gameObject.tag);
            Destroy(obj);
        }
    }
}
using UnityEngine;

namespace Script
{
    public class DestroyEvent : MonoBehaviour
    {
        public void Destroy()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
            foreach (var obj in objs)
            {
                if (obj.GetComponent<DestroyEvent>()) Destroy(obj);
            }
        }
    }
}
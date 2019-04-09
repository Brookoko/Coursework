using UnityEngine;

namespace Script
{
    public class DestroyObject : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

namespace Script.SaveLoad
{
    public class DeleteEntityFromScene : MonoBehaviour
    {
        [SerializeField] private Transform[] entities;

        public void Remove()
        {
            foreach (Transform e in entities)
            {
                if (e) e.transform.position = new Vector3(1000000, 1000000, 1000000);
            }
        }
    }
}
using UnityEngine;

namespace Script.Menu
{
    public class RemoveFromDontDestroyOnLoad : MonoBehaviour
    {
        public void Remove()
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (!player) return;
            foreach (GameObject obj in player.scene.GetRootGameObjects())
            {
                Destroy(obj);
            }
        }
    }
}
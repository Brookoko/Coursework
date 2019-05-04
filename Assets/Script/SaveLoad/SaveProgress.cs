using UnityEngine;

namespace Script.SaveLoad
{
    public class SaveProgress : MonoBehaviour
    {
        public void Save()
        {
            GameObject player = GameObject.FindWithTag("Player");
            SaveLoadProgress.Save(player.transform.position);
        }
    }
}
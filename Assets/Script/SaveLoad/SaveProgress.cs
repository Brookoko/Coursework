using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.SaveLoad
{
    public class SaveProgress : MonoBehaviour
    {
        public void Save(bool savePosition)
        {
            if (savePosition)
            {
                GameObject player = GameObject.FindWithTag("Player");
                SaveLoadProgress.SetPos(SceneManager.GetActiveScene().buildIndex, player.transform.position);
            }
            SaveLoadProgress.Save();
        }
    }
}
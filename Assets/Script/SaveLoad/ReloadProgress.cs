using Script.Scene;
using UnityEngine;

namespace Script.SaveLoad
{
    public class ReloadProgress : MonoBehaviour
    {
        [SerializeField] private SceneTransition manager;
        
        public void Reload()
        {
            SaveLoadProgress.OnLoad.RemoveAllListeners();
            SaveLoadProgress.OnLoad.AddListener(manager.Load);
            SaveLoadProgress.Delete();
            SaveLoadProgress.Load();
        }
    }
}
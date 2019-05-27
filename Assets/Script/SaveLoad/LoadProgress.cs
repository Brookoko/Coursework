using Script.Scene;
using UnityEngine;

namespace Script.SaveLoad
{
    public class LoadProgress : MonoBehaviour
    {
        [SerializeField] private SceneTransition manager;
        
        public void Load()
        {
            SaveLoadProgress.OnLoad.RemoveAllListeners();
            SaveLoadProgress.OnLoad.AddListener(manager.Load);
            SaveLoadProgress.Load();
        }
    }
}
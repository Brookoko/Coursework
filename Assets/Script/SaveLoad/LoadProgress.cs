using Script.Scene;
using UnityEngine;

namespace Script.SaveLoad
{
    public class LoadProgress : MonoBehaviour
    {
        [SerializeField] private SceneTransition manager;
        [SerializeField] private bool reload;
        
        private void Awake()
        {
            SaveLoadProgress.OnLoad.RemoveAllListeners();
            SaveLoadProgress.Load();
            if (SaveLoadProgress.LoadData() == null) gameObject.SetActive(false);
        }

        public void Load()
        {
            SaveLoadProgress.OnLoad.RemoveAllListeners();
            SaveLoadProgress.OnLoad.AddListener(manager.Load);
            if (reload) SaveLoadProgress.Reload();
            SaveLoadProgress.Load();
        }
    }
}
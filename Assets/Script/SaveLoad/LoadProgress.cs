using Script.Scene;
using UnityEngine;

namespace Script.SaveLoad
{
    public class LoadProgress : MonoBehaviour
    {
        [SerializeField] private SceneTransition manager;

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
            SaveLoadProgress.Load();
        }
    }
}
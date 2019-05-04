using BayatGames.SaveGameFree;
using BayatGames.SaveGameFree.Serializers;
using Script.SaveLoad;
using Script.Scene;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Script.SaveLoad
{
    public class SaveLoadProgress
    {
        public static IntEvent OnLoad;
        private static LastPoint point;

        static SaveLoadProgress()
        {
            OnLoad = new IntEvent();
        }
        
        public static void Save(Vector3 pos)
        {
            UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
            SaveLoadLevel.Save(scene);
            point = new LastPoint {level = scene.buildIndex, spawn = pos};
            SaveGame.Serializer = new SaveGameJsonSerializer();
            SaveGame.Save("LastPoint", point);
        }

        public static void Load()
        {
            SaveGame.Serializer = new SaveGameJsonSerializer();
            point = SaveGame.Exists("LastPoint") ? SaveGame.Load<LastPoint>("LastPoint") : null;
            int index = point?.level ?? 1;
            OnLoad.Invoke(index);
            if (index != 1) SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        private static void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = point.spawn;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
    
    public class IntEvent : UnityEvent<int> { }
}
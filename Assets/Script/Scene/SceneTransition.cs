using System;
using System.Collections.Generic;
using Script.Effects;
using Script.Player;
using Script.SaveLoad;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Scene
{
    public class SceneTransition : MonoBehaviour
    {
        private static readonly Dictionary<int, int> enters = new Dictionary<int, int>();
        private static string transition;
        private static Data[] data;
       
        private IEffect transitionEffect;
        private int levelIndex;
        private GameObject player;

        private void Start()
        {
            transitionEffect = GetComponent<IEffect>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Load(int index)
        {
            levelIndex = index;
            transition = SceneManager.GetActiveScene().name + "-" + NameFromIndex(index);
            transitionEffect.Play();
        }

        public void OnComplete()
        {
            SaveLoadProgress.Load();
            data = SaveLoadProgress.LoadData();
            SceneManager.LoadScene(levelIndex);
        }

        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            Restore(scene);
            SetScene(scene);
            Input.Enable();
        }
        
        private void Restore(UnityEngine.SceneManagement.Scene scene)
        {
            if (data != null)
            {
                foreach (GameObject obj in scene.GetRootGameObjects())
                {
                    Data pos = Array.Find(data, el => el.id.Equals(obj.name));
                    if (pos != null) obj.transform.position = new Vector3(pos.position[0], pos.position[1], pos.position[2]);
                }
            }
            if (enters.ContainsKey(levelIndex)) enters[levelIndex]++;
            else enters.Add(levelIndex, 0);
        }

        private void SetScene(UnityEngine.SceneManagement.Scene scene)
        {
            GameObject enter = GameObject.Find(transition);
            player = GameObject.FindWithTag("Player");
            if (player && enter)
            {
                player.transform.position = enter.transform.position;
                GameObject.Find("FallOutController")?
                    .GetComponent<FallOutController>().SetUpEnterPoint(enter);
                LevelEnter level = enter.GetComponent<LevelEnter>();
                level.SetUpScene();
                if (TimeEnter(levelIndex) == 0) level.OnFirstLoad.Invoke();
            }
        }
        
        private string NameFromIndex(int index)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(index);
            int slash = path.LastIndexOf('/');
            string name = path.Substring(slash + 1);
            int dot = name.LastIndexOf('.');
            return name.Substring(0, dot);
        }

        public static int TimeEnter(int index)
        {
            return enters.ContainsKey(index) ? enters[index] : 0;
        }
    }
}

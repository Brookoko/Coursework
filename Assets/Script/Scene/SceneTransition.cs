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
        private static LevelData data;
       
        private IEffect transitionEffect;
        private int levelIndex;
        private GameObject player;
        private bool firstEnter;

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
            SaveLoadLevel.Save(SceneManager.GetActiveScene());
            data = SaveLoadLevel.Load(NameFromIndex(levelIndex));
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
                    PositData pos = data.GetPositData(obj.name);
                    if (pos == null)
                        Destroy(obj);
                    else
                        pos.Restore(obj);
                }
                enters[levelIndex] = data.timeEnter + 1;
            }
            else
            {
                if (enters.ContainsKey(levelIndex))
                    enters[levelIndex]++;
                else
                    enters.Add(levelIndex, 0);
            }
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
                if (firstEnter) level.OnFirstLoad.Invoke();
                firstEnter = false;
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

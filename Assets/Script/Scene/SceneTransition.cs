using System;
using System.Collections.Generic;
using Script.Effects;
using Script.Player;
using Script.SaveLoad;
using Script.StateMachineUtil;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Scene
{
    public class SceneTransition : MonoBehaviour
    {
        private static string transition;
        private static Data[] data;
       
        private IEffect transitionEffect;
        private int levelIndex;
        private GameObject player;
        private Vector3 gravity = Vector3.zero;

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
            ChangeGravity();
        }

        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            Restore(scene);
            SetScene(scene);
            Input.Enable();
            SceneManager.sceneLoaded -= OnSceneLoaded;
            ChangeGravity();
        }
        
        private void Restore(UnityEngine.SceneManagement.Scene scene)
        {
            if (data == null) return;
            foreach (GameObject obj in scene.GetRootGameObjects())
            {
                Data pos = Array.Find(data, el => el.id.Equals(obj.name));
                if (pos != null)
                {
                    if (pos.position[0] > 999999)
                        Destroy(obj);
                    else
                        obj.transform.position = new Vector3(pos.position[0], pos.position[1], pos.position[2]);
                }
            }
        }

        private void SetScene(UnityEngine.SceneManagement.Scene scene)
        {
            GameObject enter = GameObject.Find(transition);
            player = GameObject.FindWithTag("Player");
            if (player && enter)
            {
                player.transform.position = enter.transform.position;
                LevelEnter level = enter.GetComponent<LevelEnter>();
                level.SetUpScene();
                GameObject.Find("FallOutController")?
                    .GetComponent<FallOutController>().SetUpEnterPoint(enter, level.lower);
                player.GetComponentInChildren<StateMachine>().ResetStates();
                level.OnFirstLoad.Invoke();
            }
            else
            {
                GameObject.Find("FallOutController")?
                    .GetComponent<FallOutController>().SetUpEnterPoint(new GameObject(), 0);
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

        private void ChangeGravity()
        {
            if (player) player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            var g = Physics.gravity;
            Physics.gravity = gravity;
            gravity = g;
        }
    }
}

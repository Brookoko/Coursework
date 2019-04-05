using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Scene
{
    public class SceneTransition : MonoBehaviour
    {
        public Animator anim;

        private int levelIndex;
        private GameObject player;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Transite(int levelIndex)
        {
            Player.Input.Disable();
            this.levelIndex = levelIndex;
            anim.SetTrigger("Fade");
        }

        public void OnComplete()
        {
            SceneManager.LoadScene(levelIndex);
        }

        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            Player.Input.Enable();
            player = GameObject.FindWithTag("Player");
            GameObject enter = GameObject.FindWithTag("EnterPoint");
            if (player && enter)
                player.transform.position = enter.transform.position;
        }
    }
}

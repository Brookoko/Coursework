using Script.Effects;
using UnityEngine;
using UnityEngine.SceneManagement;
using Input = Script.Player.StateInput.Input;

namespace Script.Scene
{
    public class SceneTransition : MonoBehaviour
    {
        private IEffect transitionEffect;
        private int levelIndex;
        private GameObject player;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            transitionEffect = GetComponent<IEffect>();
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Load(int index)
        {
            levelIndex = index;
            transitionEffect.Play();
        }

        public void OnComplete()
        {
            SceneManager.LoadScene(levelIndex);
        }

        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            Input.Enable();
            GameObject enter = GameObject.FindWithTag("EnterPoint");
            if (player && enter) player.transform.position = enter.transform.position;
        }
    }
}

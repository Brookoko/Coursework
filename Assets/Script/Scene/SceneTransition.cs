using Script.Effects;
using UnityEngine;
using UnityEngine.SceneManagement;
using Input = Script.Player.StateInput.Input;

namespace Script.Scene
{
    public class SceneTransition : MonoBehaviour
    {
        private static IEffect transiteEffect;
        private static int levelIndex;
        private static GameObject player;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            transiteEffect = GetComponent<IEffect>();
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public static void Load(int index)
        {
            levelIndex = index;
            transiteEffect.Play();
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

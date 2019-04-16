using Script.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Menu
{
    public class PlayButton : MonoBehaviour
    {
        public void OnClick()
        {
            SceneTransition.Load(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
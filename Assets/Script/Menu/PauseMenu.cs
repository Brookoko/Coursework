using UnityEngine;
using UnityEngine.SceneManagement;
using Input = Script.Player.StateInput.Input;

namespace Script.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        private static bool paused;

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Pause"))
            {
                if (paused) Restore(transform.GetChild(0).gameObject);
                else Pause(transform.GetChild(0).gameObject);
            }
        }
        
        private static void Pause(GameObject pauseMenu)
        {
            paused = true;
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
            Input.Disable();
            pauseMenu.SetActive(true);
            ToggleObjectsInScene(SceneManager.GetActiveScene());
            ToggleObjectsInScene(pauseMenu.scene);
        }

        private static void Restore(GameObject pauseMenu)
        {
            paused = false;
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.fixedUnscaledDeltaTime;
            Input.Enable();
            pauseMenu.SetActive(false);
            ToggleObjectsInScene(SceneManager.GetActiveScene());
            ToggleObjectsInScene(pauseMenu.scene);
        }

        private static void ToggleObjectsInScene(UnityEngine.SceneManagement.Scene scene)
        {
            foreach (GameObject obj in scene.GetRootGameObjects())
            {
                Animator anim = obj.GetComponent<Animator>();
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (anim) anim.enabled = !anim.enabled;
                if (rb) rb.simulated = !rb.simulated;
            }
        }
    }
}
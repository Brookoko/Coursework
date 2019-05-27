using System.Collections;
using System.Timers;
using Script.HitBox;
using Script.Scene;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Script.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        private bool paused;
        private IAlive status;
        
        private void Awake()
        {
            status = GameObject.FindWithTag("Player").GetComponentInChildren<IAlive>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Pause") && status.IsAlive())
            {
                AffectScene(transform.GetChild(0).gameObject);
            }
        }
        
        public void AffectScene(GameObject pauseMenu)
        {
            StartCoroutine(AffectSceneDelay(pauseMenu));
        }

        private IEnumerator AffectSceneDelay(GameObject pauseMenu)
        {
            yield return null;
            paused = !paused;
            ToggleTime();
            ToggleInput();
            pauseMenu.SetActive(paused);
            ToggleObjectsInScene(SceneManager.GetActiveScene());
            ToggleObjectsInScene(pauseMenu.scene);
        }

        private void ToggleObjectsInScene(UnityEngine.SceneManagement.Scene scene)
        {
            foreach (GameObject obj in scene.GetRootGameObjects())
            {
                Animator anim = obj.GetComponent<Animator>();
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (anim) anim.enabled = !anim.enabled;
                if (rb) rb.simulated = !rb.simulated;
            }
        }

        public void ToggleTime()
        {
            if (Time.timeScale < 0.01)
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = Time.fixedUnscaledDeltaTime;
            }
            else
            {
                Time.timeScale = 0;
                Time.fixedDeltaTime = 0;
            }
        }

        private void ToggleInput()
        {
            if (paused) Input.Disable();
            else Input.Enable();
        }
    }
}
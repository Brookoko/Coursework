using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Input = Script.Player.StateInput.Input;

namespace Script.Player
{
    public class FallOutController : MonoBehaviour
    {
        [SerializeField] private float offset = 2;        
        [SerializeField] private UnityEvent OutOfScreenEvent;
        
        private Vector3 enter;
        private Transform player;
        private Camera cam;
        private bool invokeAvailable = true;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        public void OnFadeEnd()
        {
            player.transform.position = enter;
            invokeAvailable = true;
            Input.Enable();
        }

        private void Update()
        {
            var posY = cam.transform.position.y - cam.orthographicSize - offset;
            if (player.transform.position.y <= posY && invokeAvailable)
            {
                invokeAvailable = false;
                OutOfScreenEvent.Invoke();
            }
        }
        
        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            enter = GameObject.FindWithTag("EnterPoint").transform.position;
            cam = Camera.main;
        }
    }
}
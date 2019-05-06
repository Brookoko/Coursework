using UnityEngine;
using UnityEngine.Events;

namespace Script.Scene
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
        }
        
        public void OnFadeOutEnd()
        {
            player.transform.position = enter;
            invokeAvailable = true;
            Input.Enable();
        }

        private void Update()
        {
            if  (!cam) cam = Camera.main;
            if (enter.Equals(Vector3.zero)) enter = player.transform.position;
            var posY = cam.transform.position.y - cam.orthographicSize - offset;
            if (player.transform.position.y <= posY && invokeAvailable)
            {
                invokeAvailable = false;
                OutOfScreenEvent.Invoke();
            }
        }
        
        public void SetUpEnterPoint(GameObject enter)
        {
            this.enter = enter.transform.position;
            cam = Camera.main;
        }
    }
}
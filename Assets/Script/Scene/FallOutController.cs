using Script.HitBox;
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
        private HitBox.HitBox hitBox;
        private Camera cam;
        private float lowerBoundry;
        private bool invokeAvailable = true;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            hitBox = player.GetComponentInChildren<HitBox.HitBox>();
        }
        
        public void OnFadeOutEnd()
        {
            hitBox.GetComponent<BaseAlive>().SetInvulnerability(1);
            player.transform.position = enter;
            invokeAvailable = true;
            Input.Enable();
        }

        private void OnEnable()
        {
            if (!cam) SetBoundry(0);
            if (enter.Equals(Vector3.zero)) enter = player.transform.position;
        }

        private void Update()
        {
            if (player.transform.position.y <= lowerBoundry && invokeAvailable)
            {
                var status = hitBox.GetComponent<IAlive>();
                invokeAvailable = false;
                status.GetDamage(1);
                if (!status.IsAlive())
                {
                    gameObject.SetActive(false);
                    Input.Disable();
                    return;
                }
                OutOfScreenEvent.Invoke();
            }
        }
        
        public void SetUpEnterPoint(GameObject enter, float lower)
        {
            if (!enter) return;
            this.enter = enter.transform.position;
            SetBoundry(lower);
        }

        public void SetBoundry(float lower)
        {
            cam = Camera.main;
            if (!cam) return;
            lowerBoundry = lower - cam.orthographicSize - offset;
        }
    }
}
using UnityEngine;

namespace Script.Scene
{
    public class CameraAttachment : MonoBehaviour
    {
        [SerializeField] private float offset;
        [SerializeField] private float smoothing;
        
        private Camera cam;
        private float height;
        private SpriteRenderer render;
        private Vector3 vel;
        
        private void Awake()
        {
            cam = Camera.main;
            render = GetComponent<SpriteRenderer>();
            height = render.sprite.bounds.size.y;
        }

        private void Update()
        {
            float camHeight = cam.orthographicSize * Screen.height / Screen.width;
            float edgeUp = transform.position.y + height / 2 - camHeight - offset;
            float edgeDown = transform.position.y - height / 2 + camHeight + offset;

            float posY = cam.transform.position.y;
            Vector3 target = transform.position;

            if (posY >= edgeUp)
            {
                target = new Vector3(transform.position.x, transform.position.y + posY - edgeUp, transform.position.z);
            } else if (posY <= edgeDown + offset)
            {
                target = new Vector3(transform.position.x, transform.position.y - edgeDown + posY, transform.position.z);
            }

            transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smoothing * Time.deltaTime);
        }

        private void Move(float y)
        {
            var target = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);
            transform.position = target;
            // transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);
        }
    }
}
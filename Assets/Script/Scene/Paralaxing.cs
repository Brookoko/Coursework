using UnityEngine;

namespace Script.Scene
{
    public class Paralaxing : MonoBehaviour
    {
        public float smoothing = 1f;

        private float scale;
        private Transform cam;
        private Vector3 prevCamPos;

        private void Awake()
        {
            cam = Camera.main.transform;
        }

        private void Start()
        {
            prevCamPos = cam.position;
            
            scale = transform.position.z * -1;
        }

        private void Update()
        {
            float paralaxX = (prevCamPos.x - cam.position.x) * scale;
            float paralaxY = (prevCamPos.y - cam.position.y) * Mathf.Abs(scale / 3);
            float layerPosX = transform.position.x + paralaxX;
            float layerPosY = transform.position.y + paralaxY;
            Vector3 targetPos = new Vector3(layerPosX, layerPosY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);

            prevCamPos = cam.position;
        }
    }
}

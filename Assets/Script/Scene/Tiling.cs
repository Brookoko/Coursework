using UnityEngine;

namespace Script.Scene
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tiling : MonoBehaviour
    {
        [SerializeField] private float offsetX = 2;
        [SerializeField] private bool reverseScale;
        
        private Transform rightBody;
        private Transform leftBody;
        private float width;
        private Camera cam;

        private void Awake()
        {
            cam = Camera.main;
        }

        private void Start()
        {
            SpriteRenderer render = GetComponent<SpriteRenderer>();
            width = render.sprite.bounds.size.x;
        }

        private void Update()
        {
            float camWidth = cam.orthographicSize * Screen.width / Screen.height;
            float edgeRight = transform.position.x + width / 2 - camWidth;
            float edgeLeft = transform.position.x - width / 2 + camWidth;

            var posX = cam.transform.position.x;
            if (posX >= edgeRight - offsetX && !rightBody) rightBody = AddNewBody(1);
            else if (posX >= edgeRight + width * 2 + camWidth) Destroy();
            else if (posX <= edgeLeft + offsetX && !leftBody) leftBody = AddNewBody(-1);
            else if (posX <= edgeLeft - width * 2 - camWidth) Destroy();
        }

        private Transform AddNewBody(int side)
        {
            Vector3 pos = transform.position;
            Vector3 bodyPos = new Vector3(pos.x + width * side, pos.y, pos.z);
            Transform body = Instantiate(transform, bodyPos, transform.rotation);
            body.parent = transform.parent;

            var tile = body.GetComponent<Tiling>();
            if (side == 1) tile.leftBody = transform;
            else tile.rightBody = transform;
        
            if (reverseScale) Flip(body);
            
            return body;
        }

        private void Flip(Transform body)
        {
            var scale = body.lossyScale;
            scale.x *= -1;
            body.localScale = scale;
        }

        private void Destroy()
        {
            if (rightBody) rightBody.GetComponent<Tiling>().leftBody = null;
            if (leftBody) leftBody.GetComponent<Tiling>().rightBody = null;
            Destroy(gameObject);
        }
    }
}
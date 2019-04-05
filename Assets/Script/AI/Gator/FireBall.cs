using System.Timers;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

namespace Script.AI.Gator
{
    public class FireBall : MonoBehaviour
    {
        [SerializeField] private float lifeTime;
        [SerializeField] private float speed;

        private Vector3 targetPos;
        private Vector3 startPos;
        private Rigidbody2D rb;
        private float timer;
        private int scale;
        
        private void Start()
        {
            startPos = transform.position;
            targetPos = GameObject.FindWithTag("Player").transform.position - startPos;
            scale = targetPos.x > 0 ? -1 : 1;
        }

        private void Update()
        {
            var thePos = transform.position;
            thePos.x = GetX();
            thePos.y = GetY();
            transform.position = thePos;
            timer += Time.deltaTime;
            if (timer >= lifeTime)
                Destroy(gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollide();
        }

        private float GetY()
        {
            return speed * 0.5f * (2 + 0.5f * speed) * (Mathf.Cos(Mathf.PI * timer / lifeTime) - 1) * 10f + startPos.y;
        }

        private float GetX()
        {
            return -speed * (1 + 0.5f * speed) * scale * Mathf.Sin(timer / lifeTime * (Mathf.PI / 2)) * 10f + startPos.x;
        }

        public void OnCollide()
        {
            Destroy(gameObject);
        }
    }
}
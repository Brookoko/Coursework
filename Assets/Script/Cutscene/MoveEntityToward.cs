using System.Collections;
using UnityEngine;

namespace Script.Cutscene
{
    public class MoveEntityToward : MonoBehaviour
    {
        [SerializeField] private new string tag;
        [SerializeField] private Vector3 target;

        private GameObject entity;
        private Rigidbody2D rb;
        
        private void Start()
        {
            entity = GameObject.FindWithTag(tag);
            rb = entity.GetComponent<Rigidbody2D>();
        }

        public void Move(float speed)
        {
            rb.velocity = Vector2.zero;
            StartCoroutine(MoveToward(speed));
        }

        private IEnumerator MoveToward(float speed)
        {
            Vector3 cur = entity.transform.position;
            while (Mathf.Abs(cur.x - target.x) > 0.1f &&
                   Mathf.Abs(cur.y - target.y) > 0.1f)
            {
                cur = entity.transform.position =
                    Vector3.MoveTowards(cur, target, speed);
                yield return null;
            }
        }
    }
}
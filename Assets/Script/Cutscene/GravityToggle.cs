using UnityEngine;

namespace Script.Cutscene
{
    public class GravityToggle : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float gravity;
        
        private void Awake()
        {
            rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            ChangeGravity();
        }
        
        private void ChangeGravity()
        {
            var g = rb.gravityScale;
            rb.gravityScale = gravity;
            gravity = g;
        }
    }
}
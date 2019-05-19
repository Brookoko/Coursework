using UnityEngine;

namespace Script
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private int points;
        
        private Score score;
        
        private void Awake()
        {
            score = GameObject.FindWithTag("Player").GetComponent<Score>();
        }

        public void Collect()
        {
            score.AddScore(points);
        }
    }
}
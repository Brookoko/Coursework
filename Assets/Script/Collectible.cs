using System.Collections;
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
            StartCoroutine(Remove());
        }

        private IEnumerator Remove()
        {
            yield return new WaitForSeconds(1);
            transform.position = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using Script.HitBox;
using UnityEngine;

namespace Script
{
    public class Heal : MonoBehaviour
    {
        [SerializeField] private int pointsToHeal;
        [SerializeField] private float timeBetweenTicks;
        [SerializeField] private float timeBtwHeal;
        
        private GameObject player;
        private Score score;
        private IAlive status;
        private float timer;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            score = player.GetComponent<Score>();
            status = player.GetComponentInChildren<IAlive>();
        }
        
        private void Update()
        {
            if (Input.GetButtonDown("Heal") && status.IsAlive() && timer < 0) StartCoroutine(Healing());
            if (Input.GetButtonUp("Heal")) StopAllCoroutines();
            timer -= Time.deltaTime;
        }

        private IEnumerator Healing()
        {
            yield return new WaitForSeconds(0.5f);
            timer = timeBtwHeal;
            score.onValueChange.AddListener(GetScore);
            for (int i = 0; i < pointsToHeal; i++)
            {
                score.AddScore(-1);
                yield return new WaitForSeconds(timeBetweenTicks);
            }
            status.GetDamage(-1);
        }

        private void GetScore(int points)
        {
            if (points < 0)
            {
                StopAllCoroutines();
                score.onValueChange.RemoveListener(GetScore);                
                score.AddScore(-points);
            }
        }
    }
}
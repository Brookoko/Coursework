using TMPro;
using UnityEngine;

namespace Script.Menu
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private Score score;
        
        private void Awake()
        {
            score = GameObject.FindWithTag("Player").GetComponent<Score>();
            score.onValueChange.AddListener(UpdateScore);
        }

        private void UpdateScore(int points)
        {
            if (points < 0) points = 0;
            text.text = points + "";
        }
    }
}
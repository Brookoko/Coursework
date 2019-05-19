using Script.SaveLoad;
using UnityEngine;

namespace Script
{
    public class Score : MonoBehaviour
    {
        public IntEvent onValueChange;
        private int score;

        public void AddScore(int points)
        {
            score += points;
            onValueChange.Invoke(score);
        }        
    }
}
using System;
using UnityEngine;

namespace Pattern
{
    public class ScoreManager2 : MonoBehaviour
    {
        private void OnEnable()
        {
            StudyEventBus.OnScoreChanged += UpdateScore;
        }

        private void OnDisable()
        {
            StudyEventBus.OnScoreChanged += UpdateScore;
        }

        private void UpdateScore(int newScore)
        {
            Debug.Log($"현제 점수 : {newScore}");
        }
    }
}

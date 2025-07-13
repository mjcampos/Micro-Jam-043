using System;
using Singletons;
using UnityEngine;
using TMPro;

public class AverageScoreTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI averageScoreText;

    void Start()
    {
        UpdateAverageScoreText();
    }

    public void UpdateAverageScoreText()
    {
        float averageScore = ScoreManager.Instance.GetAverageScore();
        
        averageScoreText.text = "Average: " + (int)averageScore + "%";
    }
}

using System;
using System.Collections;
using Helpers;
using Singletons;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

public class Submission : MonoBehaviour
{
    [SerializeField] ColorGenerator customerSelection;
    [SerializeField] ColorGenerator playerSelection;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button submitButton;
    [SerializeField] TextMeshProUGUI gameOverText;
    
    CountdownTimer countdownTimer;
    AverageScoreTracker averageScoreTracker;

    void Start()
    {
        countdownTimer = GetComponent<CountdownTimer>();
        averageScoreTracker = GetComponent<AverageScoreTracker>();
        
        gameOverText.text = "";
    }

    public void Submit()
    {
        float accuracy = ColorAccuracy.CalculateAccuracy(customerSelection.Color, playerSelection.Color);

        countdownTimer.StopAllCoroutines();
        scoreText.text = ((int)accuracy).ToString();
        
        StartCoroutine(DisableSubmitButton(accuracy));
    }

    public void FailedSubmission()
    {
        scoreText.text = "0%";
        
        StartCoroutine(DisableSubmitButton(0));
    }

    IEnumerator DisableSubmitButton(float score)
    {
        ScoreManager.Instance.SetAverageScore(score);
        averageScoreTracker.UpdateAverageScoreText();
        submitButton.interactable = false;
        
        yield return new WaitForSeconds(0.5f);

        if (ScoreManager.Instance.CanPlay)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            int averageScore = (int)ScoreManager.Instance.GetAverageScore();
            
            gameOverText.text = $"You scored an average of: {averageScore}%\nPress r to restart";
        }
    }
}

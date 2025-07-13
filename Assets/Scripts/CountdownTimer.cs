using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] float countdownTime = 10f;
    [SerializeField] TextMeshProUGUI timerText;

    float currentTime;
    Submission submission;

    void Start()
    {
        submission = GetComponent<Submission>();
    }

    void OnEnable()
    {
        StartCountdown();
    }

    void StartCountdown()
    {
        currentTime = countdownTime;
        StartCoroutine(CountdownRoutine());
    }
    
    IEnumerator CountdownRoutine()
    {
        while (currentTime > 0)
        {
            // Update UI
            timerText.text = Mathf.Ceil(currentTime).ToString("0"); // removes decimals
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        timerText.text = "0";
        OnTimerEnd();
    }

    void OnTimerEnd()
    {
        submission.FailedSubmission();
    }
}

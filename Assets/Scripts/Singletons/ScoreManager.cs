using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Singletons
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        [SerializeField] int maxRounds = 2;

        List<float> scores = new List<float>();
        float averageScore;
        bool canPlay = true;

        public bool CanPlay
        {
            get => canPlay;
            set => canPlay = value;
        }
        
        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        public void SetAverageScore(float score)
        {
            scores.Add(score);
            averageScore = scores.Average();

            if (scores.Count >= maxRounds)
            {
                canPlay = false;
            }
        }

        public float GetAverageScore()
        {
            return averageScore;
        }

        public void ResetEverything()
        {
            scores.Clear();
        }
    }
}

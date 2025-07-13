using System;
using System.Collections.Generic;
using Helpers;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance {get; private set;}
        
        bool canChangeScene = true;

        public bool CanChangeScene
        {
            get => canChangeScene;
            set => canChangeScene = value;
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
        
        void OnClick()
        {
            if (!canChangeScene) return;
            
            switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex)
            {
                case BuildIndexes.IntroScene:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(BuildIndexes.BriefingScene);
                    break;
                case BuildIndexes.BriefingScene:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(BuildIndexes.GameScene);
                    break;
                case BuildIndexes.GameScene:
                    break;
                default:
                    break;
            }
        }
    }
}

using Helpers;
using Singletons;
using UnityEngine;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

public class RestartManager : MonoBehaviour
{
    void Update()
    {
        bool canPlay = ScoreManager.Instance.CanPlay;

        if (!canPlay)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ScoreManager.Instance.ResetEverything();
                SceneManager.LoadScene(BuildIndexes.IntroScene);
            }
        }
    }
}

using Helpers;
using Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    void Update()
    {
        bool canPlay = ScoreManager.Instance.CanPlay;

        if (!canPlay)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(BuildIndexes.IntroScene);
            }
        }
    }
}

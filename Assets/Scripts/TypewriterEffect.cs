using System;
using System.Collections;
using Singletons;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] ManagerTextSO[] dialogueLines;
    [SerializeField] float delayBeforeConversation = 0.05f;
    [SerializeField] float letterDelay = 0.05f;
    [SerializeField] float delayBetweenLines = 1f;
    
    TextMeshProUGUI textComponent;

    void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        StartCoroutine(PauseBeforeCanChangeScene());
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PauseBeforeCanChangeScene()
    {
        SceneManager.Instance.CanChangeScene = false;
        yield return new WaitForSeconds(0.5f);
        SceneManager.Instance.CanChangeScene = true;
    }

    IEnumerator  PlayDialogue()
    {
        yield return new WaitForSeconds(delayBeforeConversation);
        
        foreach (ManagerTextSO line in dialogueLines)
        {
            string text = line.Text;

            yield return StartCoroutine(TypeLine(text));
            yield return new WaitForSeconds(delayBetweenLines);
        }
    }

    IEnumerator TypeLine(string text)
    {
        textComponent.text = "";

        foreach (char c in text)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}

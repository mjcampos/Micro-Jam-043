using System;
using System.Collections;
using TMPro;
using UI;
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
        SceneManager.Instance.CanChangeScene = false;
        StartCoroutine(PlayDialogue());
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
        
        SceneManager.Instance.CanChangeScene = true;
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

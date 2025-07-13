using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] ManagerTextSO[] dialogueLines;
    [SerializeField] float letterDelay = 0.05f;
    [SerializeField] float delayBetweenLines = 1f;
    
    TextMeshProUGUI _textComponent;

    void Awake()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        StartCoroutine(PlayDialogue());
    }

    IEnumerator  PlayDialogue()
    {
        foreach (ManagerTextSO line in dialogueLines)
        {
            string text = line.Text;

            yield return StartCoroutine(TypeLine(text));
            yield return new WaitForSeconds(delayBetweenLines);
        }
    }

    IEnumerator TypeLine(string text)
    {
        _textComponent.text = "";

        foreach (char c in text)
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}

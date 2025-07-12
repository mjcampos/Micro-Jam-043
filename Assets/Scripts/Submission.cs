using Helpers;
using UnityEngine;
using UnityEngine.UI;

public class Submission : MonoBehaviour
{
    [SerializeField] ColorGenerator customerSelection;
    [SerializeField] ColorGenerator playerSelection;
    
    public void Submit()
    {
        float accuracy = ColorAccuracy.CalculateAccuracy(customerSelection.Color, playerSelection.Color);
        
        Debug.Log(accuracy);
    }
}

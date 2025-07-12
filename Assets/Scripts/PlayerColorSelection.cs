using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorSelection : ColorGenerator
{
    [SerializeField] FlexibleColorPicker flexibleColorPicker;
    
    RawImage _rawImage;

    void Awake()
    {
        _rawImage = GetComponent<RawImage>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Color = GenerateRandomColor();
        
        flexibleColorPicker.SetColor(Color);
        _rawImage.color = Color;
    }

    public void UpdatePlayerColor(Color color)
    {
        Color = color;
        _rawImage.color = Color;
    }
}

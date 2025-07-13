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

    void Start()
    {
        Color = GenerateRandomColor();
        
        flexibleColorPicker.SetColor(Color);
        _rawImage.color = Color;
    }

    public void UpdatePlayerColor(Color color)
    {
        Color = color;

        if (_rawImage)
        { 
            _rawImage.color = Color;
        }
    }
}

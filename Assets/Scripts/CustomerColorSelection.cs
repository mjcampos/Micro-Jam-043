using UnityEngine;
using UnityEngine.UI;

public class CustomerColorSelection : ColorGenerator
{
    RawImage _rawImage;

    void Awake()
    {
        _rawImage = GetComponent<RawImage>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Color = GenerateRandomColor();
        _rawImage.color = Color;
    }
}

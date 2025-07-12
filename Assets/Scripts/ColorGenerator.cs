using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class ColorGenerator : MonoBehaviour
{
    public Color Color { get; set; }

    public Color GenerateRandomColor()
    {
        return new Color(Random.value,  Random.value, Random.value);
    }
}

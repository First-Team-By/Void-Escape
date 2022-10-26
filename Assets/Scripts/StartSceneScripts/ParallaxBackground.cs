using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float _height; 

    private float _width;

    private float _backgroundSize = 2f;

    private float _planetStretchingWidth = 3f;

    private float _StretchinPlanetHeight = 10f;

    void Start()
    {
        _height = Camera.main.orthographicSize * _backgroundSize;

        _width = _height * Screen.width / Screen.height;

        if (gameObject.name == "Background")
        {
            transform.localScale = new Vector3(_width, _height, 0);
        }
        else
        {
            transform.localScale = new Vector3 (_width + _planetStretchingWidth, _StretchinPlanetHeight, 0);
        }
    }
}

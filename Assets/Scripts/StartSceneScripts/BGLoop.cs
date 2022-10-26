using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour
{
    [Header("Скорость перемещения заднего фона")]
    [SerializeField] private float _speed;

    private Vector2 _offset = Vector2.zero;

    private Material _material;

    void Start()
    {
        _material = GetComponent<Renderer>().material;

        _offset = _material.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        _offset.x = _offset.x + _speed * Time.deltaTime;

        _material.SetTextureOffset("_MainTex", _offset);
    }
}

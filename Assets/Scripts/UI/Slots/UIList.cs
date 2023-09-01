using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIList : MonoBehaviour, IContainerHolder
{
    [SerializeField] private float _contentScale = 1;
    public Vector2 ContentScale => Vector2.one * _contentScale;
}

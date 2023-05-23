using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterPosition : MonoBehaviour
{
    [SerializeField] private int _position;

    public int Position => _position;
}

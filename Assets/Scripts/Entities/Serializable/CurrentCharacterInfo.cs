using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CurrentCharacterInfo : CharacterInfo
{
    
    
    public EntityConditions CurrentConditions
    {
        get => _currentConditions;
        set => _currentConditions = value;
    }

    public int Position
    {
        get => _position;
        set => _position = value;
    }

    [SerializeField] private int _position;
    
    
    [SerializeField] private EntityConditions _currentConditions;

   
}

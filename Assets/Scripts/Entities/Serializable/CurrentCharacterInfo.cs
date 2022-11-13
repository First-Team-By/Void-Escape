using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CurrentCharacterInfo
{
    public GameObject CharacterPrefab
    {
        get => _characterPrefab;
        private set => _characterPrefab = value;
    }
    public float CurrentHealth
    {
        get => _currentHealth;
        private set => _currentHealth = value;
    }
    public EntityState CurrentState
    {
        get => _currentState;
        private set => _currentState = value;
    }

    public int Position
    {
        get => _position;
        set => _position = value;
    }

    [SerializeField] private int _position;
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private float _currentHealth;
    [SerializeField] private EntityState _currentState;

    public CurrentCharacterInfo(Character character)
    {
        CharacterPrefab = character.Prefab;
        CurrentHealth = character.Health;
        CurrentState = character.State;
        Position = character.Position;
    }
}

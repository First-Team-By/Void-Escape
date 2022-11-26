using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class EntityBase : MonoBehaviour
{
    [SerializeField] private EntityCharacteristics entityChars;
    [SerializeField] private GameObject prefab;
    [SerializeField] private EntityState _state = new EntityState();

    public EntityCharacteristics EntityChars
    {
        get => entityChars;
        set
        {
            entityChars = value;
        }
    }

    public GameObject Prefab
    {
        get => prefab;
        set => prefab = value;
    }

    public int CurrentInitiative
    {
        get
        {
            return entityChars.Initiative;
        }
    }

    public int Position { get; set; }
    public bool IsActive { get; set; }
    public abstract List<EntityCommand> Commands { get; }

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, entityChars.MaxHealth);
        }
    }

    public EntityState State
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
        }
    }

    private float _health;

    public bool TakeDamage(float damage, EntityCharacteristics provokerChars)
    {
        if (Random.Range(0, 1f) < Mathf.Clamp(entityChars.EvadeChance - provokerChars.Accuracy, 0, 1f))
        {
            return false;
        }

        if (Random.Range(0, 1f) < provokerChars.CritChance)
        {
            Health -= damage * entityChars.Defence * provokerChars.CritMultiplier;
            return true;
        }

        Health -= damage * entityChars.Defence;
        return true;
    }

    public void GetPoisoned((float damage, int duration) poisonEffects)
    {
        _state.poisonedState.isPoisoned = true;
        _state.poisonedState.poisonDamage = poisonEffects.damage;
        _state.poisonedState.duration = poisonEffects.duration;
    }
    public void GetBleeded((float damage, int duration) bleedEffects)
    {
        _state.bleedingState.isBleeding = true;
        _state.bleedingState.bleedDamage = bleedEffects.damage;
        _state.bleedingState.duration = bleedEffects.duration;
    }
}

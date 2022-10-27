using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class EntityBase : MonoBehaviour
{
    [SerializeField] private EntityCharacteristics entityChars;

    public int Position { get; set; }
    public abstract List<EntityCommand> Commands(); 

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, entityChars._maxHealth);
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
    private EntityState _state;

    public bool TakeDamage(float damage, EntityCharacteristics provokerChars)
    {
        if (Random.Range(0, 1f) < Mathf.Clamp(entityChars._evadeChance - provokerChars._accuracy, 0, 1f))
        {
            return false;
        }

        if (Random.Range(0, 1f) < provokerChars._critChance)
        {
            Health -= damage * entityChars._defence * provokerChars._critMultiplier;
            return true;
        }

        Health -= damage * entityChars._defence;
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

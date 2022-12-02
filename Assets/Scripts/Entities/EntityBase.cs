using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class EntityBase : MonoBehaviour
{
    [SerializeField] private EntityCharacteristics entityChars;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Sprite portrait;
    [SerializeField] private EntityConditions _conditions = new EntityConditions();
    [SerializeField] private Sprite sufferingPose;
    [SerializeField] private Sprite attackPose;

    public string Name { get; set; }
    public Sprite SufferingPose => sufferingPose;
    public Sprite AttackPose => attackPose;
    public Sprite Portrait => portrait;

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

    public EntityConditions Conditions
    {
        get
        {
            return _conditions;
        }
        set
        {
            _conditions = value;
        }
    }

    private float _health;

    public TargetState TakeDamage(float damage, EntityCharacteristics provokerChars, Sprite effect)
    {
        var result = new TargetState();
        if (Random.Range(0, 1f) < Mathf.Clamp(entityChars.EvadeChance - provokerChars.Accuracy, 0, 1f))
        {
            result.Pose = EntityPose.EvadePose;
            return result;
        }

        var finalDamage = damage;
        if (Random.Range(0, 1f) < provokerChars.CritChance)
        {
            finalDamage *= provokerChars.CritMultiplier;
        }

        finalDamage *= entityChars.Defence;

        Health -= finalDamage;
        result.Pose = EntityPose.SufferingPose;
        result.HealthChanged = -finalDamage;
        result.Target = this;
        result.Effect = effect;
        return result;
    }

    public TargetState GetHealth(float health, Sprite effect)
    {
        var result = new TargetState(); 
        Health += health;
        result.Pose = EntityPose.ReinforcedPose;
        result.HealthChanged = health;
        result.Target = this;
        result.Effect = effect;
        return result;
    }

    public void GetPoisoned((float damage, int duration) poisonEffects)
    {
        _conditions.poisoned.isPoisoned = true;
        _conditions.poisoned.poisonDamage = poisonEffects.damage;
        _conditions.poisoned.duration = poisonEffects.duration;
    }
    public void GetBleeded((float damage, int duration) bleedEffects)
    {
        _conditions.bleeding.isBleeding = true;
        _conditions.bleeding.bleedDamage = bleedEffects.damage;
        _conditions.bleeding.duration = bleedEffects.duration;
    }

    public virtual Sprite GetSufferingPose()
    {
        return sufferingPose;
    }

    public virtual Sprite GetAttackPose()
    {
        return attackPose;
    }
}

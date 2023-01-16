using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EntityClass
{
    Officer = 0,
    Medic = 1,
    Mutant = 2
}

public abstract class EntityBase : MonoBehaviour
{
    [SerializeField] private EntityCharacteristics entityChars;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Sprite portrait;
    [SerializeField] private EntityConditions _conditions = new EntityConditions();
    [SerializeField] private Sprite sufferingPose;
    [SerializeField] private Sprite attackPose;
    [SerializeField] private Sprite deathDoorSprite;
    public string Name { get; set; }
    public Sprite SufferingPose => sufferingPose;
    public Sprite AttackPose => attackPose;
    public Sprite Portrait => portrait;
    public Sprite DeathDoorSprite => deathDoorSprite;
    
    public bool OnDeathDoor { get; set; }

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

    private static string[] entityClassNames = new string[] { "Officer", "Medic", "Mutant" };

    public string ClassName
    {

        get { return GetClassName(entityClass); }
    }

    public static string GetClassName(EntityClass entityClass)
    {
        return entityClassNames[Convert.ToInt32(entityClass)];
    }

    public int Position { get; set; }
    public bool IsActive { get; set; }
    public abstract List<EntityCommand> Commands { get; }
    public event Action<EntityBase> HealthOver;

    public EntityClass EntityClass => entityClass;
    [SerializeField] private EntityClass entityClass;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, entityChars.MaxHealth);
            if (_health <= 0)
            {
                OnDeathDoor = true;
                HealthOver?.Invoke(this);
                GetComponent<SpriteRenderer>().sprite = DeathDoorSprite;
            }
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

    void Awake()
    {
        Health = EntityChars.MaxHealth;
        Init();
    }

    protected virtual void Init() { }

    public TargetState TakeDamage(float damage, EntityCharacteristics provokerChars, Sprite effect, Conditioning conditioning)
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

        if (finalDamage > 0 && conditioning.CanGetBleed)
        {
            var chance = Random.Range(0, 1);
            if (chance <= conditioning.Bleeding.Chance)
            {
                Debug.Log("success");
                GetBleeded(conditioning.Bleeding.Damage, conditioning.Bleeding.Duration);
            }
        }

        Health -= finalDamage;
        result.Pose = EntityPose.SufferingPose;
        result.HealthChanged = -finalDamage;
        result.Target = this;
        result.Effect = effect;
        return result;
    }

    private TargetState TakeDamage(float damage, Sprite effect = null)
    {
        var result = new TargetState();
        result.Pose = EntityPose.SufferingPose;
        result.HealthChanged -= damage;
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
    public void GetBleeded(float damage, int duration)
    {
        _conditions.bleeding.bleedDamage = damage;
        _conditions.bleeding.duration = duration;
    }

    public virtual Sprite GetSufferingPose()
    {
        return sufferingPose;
    }

    public virtual Sprite GetAttackPose()
    {
        return attackPose;
    }

    public List<TargetState> ProcessConditions()
    {
        List<TargetState> results = new List<TargetState>();
        if (_conditions.IsBleeding)
        {
            results.Add(TakeDamage(_conditions.bleeding.bleedDamage));
            _conditions.bleeding.duration--;
        }


        return results;
    }
}



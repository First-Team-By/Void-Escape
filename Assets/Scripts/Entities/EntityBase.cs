using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
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
    [SerializeField] private Sprite evadePose;
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
        set => entityChars = value;
    }

    public GameObject Prefab
    {
        get => prefab;
        set => prefab = value;
    }
    
    public Sprite ProfileSprite
    {
        get { return GetComponent<SpriteRenderer>().sprite; }
    }

    public int CurrentInitiative => entityChars.Initiative;

    private static string[] entityClassNames = new string[] { "Officer", "Medic", "Mutant" };

    public string ClassName => GetClassName(entityClass);

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
        get => _health;
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
        get => _conditions;
        set => _conditions = value;
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
            //result.Pose = EntityPose.EvadePose;
            result.PoseName = Poses.Evade;
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
            var chance = Random.Range(0, 1f);
            if (chance <= conditioning.Bleeding.Chance)
            {
                GetBleeded(conditioning.Bleeding.Damage, conditioning.Bleeding.Duration);
            }
        }

        if (finalDamage > 0 && conditioning.CanGetPoison)
        {
            var chance = Random.Range(0, 1f);
            if (chance <= conditioning.Poisoning.Chance)
            {
                GetPoisoned(conditioning.Poisoning.Damage, conditioning.Poisoning.Duration);
            }
        }

        if (finalDamage > 0 && conditioning.CanGetArson)
        {
            var chance = Random.Range(0, 1f);
            if (chance <= conditioning.Arsoning.Chance)
            {
                GetArsoned(conditioning.Arsoning.Damage, conditioning.Arsoning.Duration);
            }
        }

        Health -= finalDamage;
        //result.Pose = EntityPose.SufferingPose;
        result.PoseName = Poses.Suffering;
        result.HealthChanged = -finalDamage;
        result.Target = this;
        result.Effect = effect;
        return result;
    }

    

    private TargetState TakeDamage(float damage, string reason, Sprite effect = null)
    {
        Health-= damage;

        var result = new TargetState();
        //result.Pose = EntityPose.SufferingPose;
        result.PoseName = Poses.Suffering;
        result.HealthChanged = -damage;
        result.Target = this;
        result.Effect = effect;
        result.ConditionName = reason;

        return result;
    }

    public TargetState GetHealth(float health, Sprite effect)
    {
        var result = new TargetState(); 
        Health += health;
        //result.Pose = EntityPose.ReinforcedPose;
        result.PoseName = Poses.Reinforced;
        result.HealthChanged = health;
        result.Target = this;
        result.Effect = effect;
        return result;
    }

    public void GetPoisoned(float damage, int duration)
    {
        _conditions.poisoning.poisonDamage = damage;
        _conditions.poisoning.duration = duration;
    }
    public void GetBleeded(float damage, int duration)
    {
        _conditions.bleeding.bleedDamage = damage;
        _conditions.bleeding.duration = duration;
    }

    private void GetArsoned(float damage, int duration)
    {
        _conditions.arsoning.arsonDamage = damage;
        _conditions.arsoning.duration = duration;
    }

    public TargetState StopBleeding(Sprite effect)
    {
        var result = new TargetState();
        //result.Pose = EntityPose.ReinforcedPose;
        result.PoseName = Poses.Reinforced;
        result.Target = this;
        result.Effect = effect;
        _conditions.bleeding.duration = 0;

        return result;
    }

    public TargetState StopPoisoning(Sprite effect)
    {
        var result = new TargetState();
        //result.Pose = EntityPose.ReinforcedPose;
        result.PoseName = Poses.Reinforced;
        result.Target = this;
        result.Effect = effect;
        _conditions.poisoning.duration = 0;

        return result;
    }

    public virtual Sprite GetSufferingPose()
    {
        return sufferingPose;
    }

    public virtual Sprite GetAttackPose()
    {
        return attackPose;
    }

    public virtual Sprite GetPose(string pose)
    {
        switch (pose)
        {
            case Poses.Evade: return evadePose;

            case Poses.Suffering: return sufferingPose;

            default: return GetCustomPose(pose);
        }
    }

    public virtual Sprite GetCustomPose(string pose)
    {
        return null;
    }

    public List<TargetState> ProcessConditions()
    {
        List<TargetState> results = new List<TargetState>();
        if (_conditions.IsBleeding)
        {
            results.Add(TakeDamage(_conditions.bleeding.bleedDamage, "Кровотечение"));
            _conditions.bleeding.duration--;
        }

        if (_conditions.IsPoisoned)
        {
            results.Add(TakeDamage(_conditions.poisoning.poisonDamage, "Яд"));
            _conditions.poisoning.duration--;
        }

        if (_conditions.IsArsoned)
        {
            results.Add(TakeDamage(_conditions.arsoning.arsonDamage, "Поджог"));
            _conditions.arsoning.duration--;
        }
        return results;
    }
}



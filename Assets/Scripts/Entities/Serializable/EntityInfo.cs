using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class EntityInfo
{
    //[SerializeField] private EntityCharacteristics entityChars;
    //[SerializeField] private Sprite portrait;
    //[SerializeField] private EntityConditions _conditions = new EntityConditions();
    //[SerializeField] private Sprite sufferingPose;
    //[SerializeField] private Sprite attackPose;
    //[SerializeField] private Sprite evadePose;
    //[SerializeField] private Sprite deathDoorSprite;
    //[SerializeField] private EntityClass entityClass;

    private EntityCharacteristics _entityChars;

    public string Name { get; set; }
    public Sprite SufferingPose { get; private set; }
    public Sprite AttackPose { get; private set; }
    public Sprite Portrait { get; private set; }
    public Sprite DeathDoorSprite { get; private set; }
    public Sprite FullFaceSprite { get; private set; }
    public Sprite EvadePose { get; private set; }
    public abstract string SufferingPoseName { get; }
    public abstract string AttackPoseName { get; }
    public abstract string PortraitName { get; }
    public abstract string DeathDoorSpriteName { get; }
    public abstract string FullFaceSpriteName { get; }
    public abstract string EvadePoseName { get; }
    public EntityClass EntityClass { get; protected set; }
    public EntityCharacteristics EntityChars 
    {
        get
        {
            return ApplyConditions(_entityChars);
        }          
    }

    public EntityCharacteristics OriginalEntityChars => _entityChars;

    protected EntityConditions _conditions = new EntityConditions();
    public EntityConditions Conditions
    {
        get => _conditions;
        set => _conditions = value;
    }

    private string _fullName;

    public bool OnDeathDoor { get; set; }
    
    public EntityResistances NaturalResistance
    {
        get => _naturalResistance;
        set => _naturalResistance = value;
    }

    private EntityResistances _naturalResistance;

    public virtual EntityResistances Resistances { get => NaturalResistance; }

    public float Health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, EntityChars.MaxHealth);
            if (_health <= 0)
            {
                OnDeathDoor = true;
                HealthOver?.Invoke(this);
            }
        }
    }

    private static string[] entityClassNames = new string[] { "Офицер", "Медик", "Мутант", "Супер мутант", "Офицер" };

    public string ClassName => GetClassName(EntityClass);

    public string FullName
    {
        get
        {
            return _fullName;
        }
        set
        {
            _fullName = value;
        }
    }

    public int Position { get; set; }
    public bool IsActive { get; set; }
    public abstract List<EntityCommand> Commands { get; }
    public event Action<EntityInfo> HealthOver;

    public int CurrentInitiative => EntityChars.Initiative;
    private float _health;

    public EntityInfo()
    {
        _entityChars = CharsTemplate.GetCharacteristics(this.GetType());
        _health = EntityChars.MaxHealth;
        AttackPose = Resources.Load<Sprite>("Sprites/Entities/" + AttackPoseName);
        EvadePose = Resources.Load<Sprite>("Sprites/Entities/" + EvadePoseName);
        FullFaceSprite = Resources.Load<Sprite>("Sprites/Entities/" + FullFaceSpriteName);
        Portrait = Resources.Load<Sprite>("Sprites/Entities/" + PortraitName);
        DeathDoorSprite = Resources.Load<Sprite>("Sprites/Entities/" + DeathDoorSpriteName);
        SufferingPose = Resources.Load<Sprite>("Sprites/Entities/" + SufferingPoseName);

        NaturalResistance = new EntityResistances();
    }

    public EntityCharacteristics ApplyConditions(EntityCharacteristics entityChars)
    {
        var result = entityChars.Clone();

        if (_conditions.ArmBroken)
        {
            result.MeleeDamage *= 0.7f;
            result.Accuracy *= 0.7f;
        }

        if (_conditions.LegBroken)
        {
            result.Initiative /= 2;
            result.EvadeChance /= 2;
        }

        foreach (var mutilation in _conditions.Mutilations)
        {
            mutilation.Affect(result);
        }

        return result;
    }

    public TargetState TakeDamage(float damage, EntityCharacteristics provokerChars, Sprite effect, Conditioning conditioning)
    {
        var result = new TargetState();
        result.Target = this;

        if (Random.Range(0, 1f) < Mathf.Clamp(EntityChars.EvadeChance - provokerChars.Accuracy, 0, 1f))
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

        finalDamage -= finalDamage * Resistances.DamageResistance / 100;

        if (finalDamage > 0 && conditioning.CanGetBleed)
        {
            var chance = Random.Range(0, 1f);
            if (chance <= conditioning.Bleeding.Chance - conditioning.Bleeding.Chance * Resistances.BleedResistance / 100)
            {
                GetBleeded(conditioning.Bleeding.Damage, conditioning.Bleeding.Duration);
            }
        }

        if (finalDamage > 0 && conditioning.CanGetPoison)
        {
            var chance = Random.Range(0, 1f);
            if (chance <= conditioning.Poisoning.Chance - conditioning.Poisoning.Chance * Resistances.PoisonResistance / 100)
            {
                GetPoisoned(conditioning.Poisoning.Damage, conditioning.Poisoning.Duration);
            }
        }

        if (finalDamage > 0 && conditioning.CanGetArson)
        {
            var chance = Random.Range(0, 1f);
            if (chance <= conditioning.Burning.Chance - conditioning.Burning.Chance * Resistances.BurnResistance / 100)
            {
                GetBurn(conditioning.Burning.Damage, conditioning.Burning.Duration);
            }
        }

        Health -= finalDamage;
        result.PoseName = Poses.Suffering;
        result.HealthChanged = -finalDamage;
        result.Effect = effect;
        return result;
    }

    private TargetState TakeDamage(float damage, string reason, Sprite effect = null)
    {
        Health -= damage;

        var result = new TargetState();
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
        result.PoseName = Poses.Buffed;
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

    private void GetBurn(float damage, int duration)
    {
        _conditions.burning.burningDamage = damage;
        _conditions.burning.duration = duration;
    }

    public TargetState StopBleeding(Sprite effect)
    {
        var result = new TargetState();
        result.PoseName = Poses.Buffed;
        result.Target = this;
        result.Effect = effect;
        _conditions.bleeding.duration = 0;

        return result;
    }

    public TargetState StopPoisoning(Sprite effect)
    {
        var result = new TargetState();
        result.PoseName = Poses.Buffed;
        result.Target = this;
        result.Effect = effect;
        _conditions.poisoning.duration = 0;

        return result;
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

        if (_conditions.IsBurning)
        {
            results.Add(TakeDamage(_conditions.burning.burningDamage, "Поджог"));
            _conditions.burning.duration--;
        }
        return results;
    }

    public virtual Sprite GetPose(string pose)
    {
        switch (pose)
        {
            case Poses.Evade: return EvadePose;

            case Poses.Suffering: return SufferingPose;

            default: return GetCustomPose(pose);
        }
    }

    public virtual Sprite GetCustomPose(string pose)
    {
        return null;
    }
    public static string GetClassName(EntityClass entityClass)
    {
        return entityClassNames[Convert.ToInt32(entityClass)];
    }
}

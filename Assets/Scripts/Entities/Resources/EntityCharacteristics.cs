using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity Characteristics", menuName = "Game/Entities/Entity Characteristics")]
public class EntityCharacteristics : ScriptableObject
{
	
	[SerializeField] private EntityClass _entityClass;
	[SerializeField] private Type _entityType;
	[SerializeField] private float _maxHealth;
	[SerializeField] private float _meleeDamage;

	[Range(0, 1)]
	[SerializeField] private float _critChance;

	[Range(1, 2)]
	[SerializeField] private float _critMultiplier;

	[Range(0,1)]
	[SerializeField] private float _evadeChance;

	[Range(0, 1)]
	[SerializeField] private float _accuracy;

	[Range(0, 0.8f)] 
	[SerializeField] private float _defence;

	[SerializeField] private int _initiative;
	[SerializeField] private int _value;
	[SerializeField] private bool _isQuestEntity;
	[SerializeField] private bool _isGenerable = true;

	public float MaxHealth
	{
		get
		{
			return _maxHealth;
		}
		set
		{
			_maxHealth = value;
		}
	}

	public float MeleeDamage
	{   get 
		{ 
			return _meleeDamage;
		}
		set
		{
			_meleeDamage = value;
		}
	}
	public float CritChance
	{
		get
		{
			return _critChance;
		}
		set
		{
			_critChance = value;
		}
	}

	public float CritMultiplier
	{
		get
		{
			return _evadeChance;
		}
		set
		{
			_evadeChance = value;
		}
	}

	public float EvadeChance
	{
		get
		{
			return _evadeChance;
		}
		set
		{
			_evadeChance = value;
		}
	}

	public float Accuracy
	{
		get
		{
			return _accuracy;
		}
		set
		{
			_accuracy = value;
		}
	}

	public float Defence
	{
		get
		{
			return _defence;
		}
		set
		{
			_defence = value;
		}
	}

	public int Initiative
	{
		get
		{
			return _initiative;
		}
		set
		{
			_initiative = value;
		}
	}
	
	public bool IsGenerable
	{
		get
		{
			return _isGenerable;
		}
		set
		{
			_isGenerable = value;
		}
	}
	
	public bool IsQuestEntity => _isQuestEntity;

	public int Value => _value;
	public EntityClass EntityClass => _entityClass;
	public Type EntityType => _entityType;

	public EntityCharacteristics Clone()
	{
		return MemberwiseClone() as EntityCharacteristics;
	}
}

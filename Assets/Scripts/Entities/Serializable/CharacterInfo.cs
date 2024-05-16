﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System;

public enum Rarity
{
	Unique = 0,
	Common = 1,
	Rare = 2,
	Epic = 3,
	Legendary = 4,
	Mythical = 5,  
}

public enum MedicalState
{
	Idle = 0,
	RestoreHealth = 1, 
	CureTrauma = 2,
	CureMutilation = 3,
	Implantation = 4

}

public abstract class CharacterInfo : EntityInfo
{
	public static string[] RarityNames = new string[6]
	{
		"Уникальный",
		"<color=#ffffffff>Обычный</color>",
		"<color=#0000ffff>Редкий</color>",
		"Эпический",
		"Легендарный",
		"Мифический"
	};

	protected float _currentHealth;

	private EntityWeapon _weapon;
    private EntityDevice _device;
    public EntityWeapon Weapon 
	{
		set 
		{
            _weapon = value;
            EquipmentChanged?.Invoke(); 
		} 
		get { return _weapon; }
	}
	public EntityDevice Device
    {
        set
        {
            _device = value;
            EquipmentChanged?.Invoke();
        }
        get { return _device; }
    }
	public EntityArmor Armor { set; get; }
	public Rarity Rarity { set; get; } = Rarity.Common;
	public string RarityToString => RarityNames[(int)Rarity];
	public MedicalState MedicalState { set; get; }
	public Action<CharacterInfo> AddedToTeam;
    public Action EquipmentChanged;

    public void OnAddedToTeam()
	{
		AddedToTeam?.Invoke(this);
	}

	public override EntityResistances Resistances
	{
		get
		{
			return NaturalResistance + Armor.Resistances;
		}
	}

	public float CurrentHealth
	{
		get => _currentHealth;
		set => _currentHealth = value;
	}

	public int Id { get; set; }

	public abstract List<CharacterCommand> NativeCommands { get; }

	public override List<EntityCommand> Commands
	{
		get
		{
			return NativeCommands.Where(x => x.IsAvaliable(this)).Select(x => x as EntityCommand).ToList();
		}
	}

	public CharacterInfo() : base()
	{
		FullName = NameGenerator.CreateFullName();
	}

	public void ApplyMedication()
	{
		switch (MedicalState)
		{
			case MedicalState.RestoreHealth:
					Health = EntityChars.MaxHealth;
				break;

			case MedicalState.CureTrauma: 
				Conditions.ClearConstantCondition();
				break;

			case MedicalState.CureMutilation:
				Conditions.ClearMutilation();
				break;

			default: break;
		}

		MedicalState = MedicalState.Idle;
	}
}


﻿using Assets.Scripts.Entities.Serializable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


 public class CharacterInfo : EntityInfo
 {
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected GameObject _characterPrefab;
    [SerializeField] private EntityConditions _conditions;
    public EntityWeapon Weapon { set; get; }
    public EntityDevice Device { set; get; }
    public string FullName { get; set; }

    public float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    public GameObject CharacterPrefab
    {
        get => _characterPrefab;
        set => _characterPrefab = value;
    }

    public EntityConditions Conditions
    {
        get => _conditions;
        set => _conditions = value;
    }
    public int Id { get; set; }
}


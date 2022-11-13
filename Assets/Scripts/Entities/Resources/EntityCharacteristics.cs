using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity Characteristics", menuName = "Game/Entities/Entity Characteristics")]
public class EntityCharacteristics : ScriptableObject
{
    [SerializeField] private float _maxHealth;

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

    public float MaxHealth => _maxHealth;
    public float CritChance => _critChance;
    public float CritMultiplier => _critMultiplier;
    public float EvadeChance => _evadeChance;
    public float Accuracy => _accuracy;
    public float Defence => _defence;
    public int Initiative => _initiative;
    public int Value => _value;
}

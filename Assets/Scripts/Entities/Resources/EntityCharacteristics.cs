using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity Characteristics", menuName = "Game/Entities/Entity Characteristics")]
public class EntityCharacteristics : ScriptableObject
{
    [SerializeField] private float MaxHealth;

    [Range(0, 1)]
    [SerializeField] private float CritChance;

    [Range(1, 2)]
    [SerializeField] private float CritMultiplier;

    [Range(0,1)]
    [SerializeField] private float EvadeChance;

    [Range(0, 1)]
    [SerializeField] private float Accuracy;

    [Range(0, 0.8f)] 
    [SerializeField] private float Defence;

    [SerializeField] private int Initiative;

    public float _maxHealth => MaxHealth;
    public float _critChance => CritChance;
    public float _critMultiplier => CritMultiplier;
    public float _evadeChance => EvadeChance;
    public float _accuracy => Accuracy;
    public float _defence => Defence;
    public int _initiative => Initiative;
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class EntityCardBase : MonoBehaviour
{
    [SerializeField] private TMP_Text _meleeDamage;

    [SerializeField] private TMP_Text _critChance;

    [SerializeField] private TMP_Text _critMultiplier;

    [SerializeField] private TMP_Text _evadeChance;

    [SerializeField] private TMP_Text _accuracy;

    [SerializeField] private TMP_Text _defence;

    [SerializeField] private TMP_Text _damageResistance;
    [SerializeField] private TMP_Text _bleedResistance;
    [SerializeField] private TMP_Text _burnResistance;
    [SerializeField] private TMP_Text _poisonResistance;

    private void Start()
    {
        Init();
    }

    protected abstract void Init();

    public void FillInfo(EntityInfo entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _meleeDamage.text = entity.EntityChars.MeleeDamage.ToString();

        _critChance.text = entity.EntityChars.CritChance.ToString();

        _critMultiplier.text = entity.EntityChars.CritMultiplier.ToString();

        _evadeChance.text = entity.EntityChars.EvadeChance.ToString();

        _accuracy.text = entity.EntityChars.Accuracy.ToString();

        _defence.text = entity.EntityChars.Defence.ToString();

        _damageResistance.text = entity.Resistances.DamageResistance.ToString();
        _bleedResistance.text = entity.Resistances.BleedResistance.ToString();
        _burnResistance.text = entity.Resistances.BurnResistance.ToString();
        _poisonResistance.text = entity.Resistances.PoisonResistance.ToString();

        FillAdditional(entity);
    }

    public abstract void FillAdditional(EntityInfo entity);
}

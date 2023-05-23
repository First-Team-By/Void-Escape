using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityBattleCard : EntityCardBase
{
    [SerializeField] private TMP_Text _healthAmount;
    [SerializeField] private Image _entityPortrait;

    public override void FillAdditional(EntityInfo entity)
    {
        _healthAmount.text = $"{entity.Health} / {entity.EntityChars.MaxHealth}";
        _entityPortrait.sprite = entity.Portrait;
    }

    protected override void Init()
    {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityBattleCard : EntityCardBase
{
    [SerializeField] private TMP_Text _healthAmount;

    public override void FillAdditional(EntityInfo entity)
    {
        _healthAmount.text = $"{entity.Health} / {entity.EntityChars.MaxHealth}";
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityBattleCard : EntityCardBase
{
    [SerializeField] private TMP_Text _healthAmountText;

    public override void FillInfo(EntityBase entity)
    {
        base.FillInfo(entity);

        if (entity is null)
        {
            gameObject.SetActive(false);

            return;
        }

        _healthAmountText.text = $"{entity.Health} / {entity.EntityChars.MaxHealth}";
    }
}

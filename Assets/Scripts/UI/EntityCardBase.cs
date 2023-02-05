using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityCardBase : MonoBehaviour
{
    [SerializeField] private TMP_Text _meleeDamage;

    [SerializeField] private TMP_Text _critChance;

    [SerializeField] private TMP_Text _critMultiplier;

    [SerializeField] private TMP_Text _evadeChance;

    [SerializeField] private TMP_Text _accuracy;

    [SerializeField] private TMP_Text _defence;

    public virtual void FillInfo(EntityBase entity)
    {
        if (entity is null)
        {
            gameObject.SetActive(false);

            return;
        }

        _meleeDamage.text = entity.EntityChars.MeleeDamage.ToString();

        _critChance.text = entity.EntityChars.CritChance.ToString();

        _critMultiplier.text = entity.EntityChars.CritMultiplier.ToString();

        _evadeChance.text = entity.EntityChars.EvadeChance.ToString();

        _accuracy.text = entity.EntityChars.Accuracy.ToString();

        _defence.text = entity.EntityChars.Defence.ToString();
    }
}

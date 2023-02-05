using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EntityCardBase : MonoBehaviour
{
    [SerializeField] private Text _meleeDamage;

    [SerializeField] private Text _critChance;

    [SerializeField] private Text _critMultiplier;

    [SerializeField] private Text _evadeChance;

    [SerializeField] private Text _accuracy;

    [SerializeField] private Text _defence;

    public virtual void FillInfo(EntityBase entity)
    {
        if (entity is null)
        {
            gameObject.SetActive(false);

            return;
        }

        gameObject.SetActive(true);
        _meleeDamage.text = entity.EntityChars.MeleeDamage.ToString();

        _critChance.text = entity.EntityChars.CritChance.ToString();

        _critMultiplier.text = entity.EntityChars.CritMultiplier.ToString();

        _evadeChance.text = entity.EntityChars.EvadeChance.ToString();

        _accuracy.text = entity.EntityChars.Accuracy.ToString();

        _defence.text = entity.EntityChars.Defence.ToString();

    }
}

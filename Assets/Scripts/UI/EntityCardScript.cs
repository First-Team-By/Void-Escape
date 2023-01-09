using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityCardScript : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Text _entityType;

    [SerializeField] private Image _currentHealth;

    [SerializeField] private Text _meleeDamage;

    [SerializeField] private Text _critChance;

    [SerializeField] private Text _critMultiplier;

    [SerializeField] private Text _evadeChance;

    public void FillInfo(EntityBase entity)
    {
        if (entity is null)
        {
            gameObject.SetActive(false);

            return;
        }

        gameObject.SetActive(true);

        _currentHealth.fillAmount = entity.Health / entity.EntityChars.MaxHealth;

        _image.sprite = entity.Portrait;

        _entityType.text = entity.ClassName;

        _meleeDamage.text = entity.EntityChars.MeleeDamage.ToString();

        _critChance.text = entity.EntityChars.CritChance.ToString();

        _critMultiplier.text = entity.EntityChars.CritMultiplier.ToString();

        _evadeChance.text = entity.EntityChars.EvadeChance.ToString();
    }
}

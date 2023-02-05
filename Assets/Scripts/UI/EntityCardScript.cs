using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityCardScript : EntityCardBase
{
    [SerializeField] private Image _image;

    [SerializeField] private Image _currentHealth;

    [SerializeField] private TMP_Text _entityType;

    [SerializeField] private TMP_Text _initiative;


    public TMP_Text EntityType
    { 
        get { return _entityType; } 
        set { _entityType = value; } 
    }

    public override void FillInfo(EntityBase entity)
    {
        base.FillInfo(entity);

        if (entity is null)
        {
            gameObject.SetActive(false);

            return;
        }

        gameObject.SetActive(true);

        _image.sprite = entity.ProfileSprite;

        EntityType.text = entity.ClassName;

        _initiative.text = entity.EntityChars.Initiative.ToString();

        _currentHealth.fillAmount = entity.Health / entity.EntityChars.MaxHealth;
    }
}

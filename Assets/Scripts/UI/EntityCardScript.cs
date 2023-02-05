using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityCardScript : EntityCardBase
{
    [SerializeField] private Image _image;

    [SerializeField] private Text _entityType;
    
    [SerializeField] private Image _currentHealth;

    [SerializeField] private Text _initiative;

<<<<<<< HEAD
    public Text EntityType
    { 
        get { return _entityType; } 
        set { _entityType = value; } 
    }


    public void FillInfo(EntityBase entity)
=======
    public override void FillInfo(EntityBase entity)
>>>>>>> 8028954ea5a7e1fe4bac3c9c8f265a0ee3c912ec
    {
        base.FillInfo(entity);

        if (entity is null)
        {
            gameObject.SetActive(false);

            return;
        }

        _currentHealth.fillAmount = entity.Health / entity.EntityChars.MaxHealth;

        _image.sprite = entity.ProfileSprite;

        EntityType.text = entity.ClassName;

        _initiative.text = entity.EntityChars.Initiative.ToString();
    }
}

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

    [SerializeField] private Text _accuracy;

    [SerializeField] private Text _defence;

    [SerializeField] private Text _initiative;

<<<<<<< HEAD
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
=======
>>>>>>> d0009a4a11df12b954bd5b49a8a3724335d935d9

    public void FillInfo(EntityBase entity)
    {
        if (entity is null)
        {
            gameObject.SetActive(false);

            return;
        }

        gameObject.SetActive(true);

        _currentHealth.fillAmount = entity.Health / entity.EntityChars.MaxHealth;

        _image.sprite = entity.ProfileSprite;

        EntityType.text = entity.ClassName;

        _meleeDamage.text = entity.EntityChars.MeleeDamage.ToString();

        _critChance.text = entity.EntityChars.CritChance.ToString();

        _critMultiplier.text = entity.EntityChars.CritMultiplier.ToString();

        _evadeChance.text = entity.EntityChars.EvadeChance.ToString();

        _accuracy.text = entity.EntityChars.Accuracy.ToString();

        _defence.text = entity.EntityChars.Defence.ToString();

        _initiative.text = entity.EntityChars.Initiative.ToString();
    }
}

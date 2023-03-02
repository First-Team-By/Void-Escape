using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class EntityCardScript : EntityCardBase
{
    [SerializeField] private Image _image;

    [SerializeField] private Image _currentHealth;

    [SerializeField] private List<GameObject> _characterSkills; 

    [SerializeField] private TMP_Text _entityType;

    [SerializeField] private TMP_Text _initiative;

    [SerializeField] private TMP_Text _fullName;

    public TMP_Text EntityType
    { 
        get { return _entityType; } 
        set { _entityType = value; } 
    }

    public override void FillAdditional(EntityBase entity)
    {
        gameObject.SetActive(true);

        _image.sprite = entity.ProfileSprite;

        EntityType.text = entity.ClassName;

        _initiative.text = entity.EntityChars.Initiative.ToString();

        _currentHealth.fillAmount = entity.Health / entity.EntityChars.MaxHealth;

        _fullName.text = entity.FullName;

        int i = 0;

        foreach (var slotCommand in _characterSkills)
        {
            try
            {
                slotCommand.GetComponent<Image>().sprite = ((Character)entity).NativeCommands[i].Icon;

                i++;
            }
            catch (System.Exception)
            {
                slotCommand.GetComponent<Image>().sprite = null;
            }
        }
    }
}

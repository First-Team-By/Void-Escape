using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICharacterContainer : UIContainer
{
    [SerializeField] private TMP_Text NameText;
    public CharacterInfo Character => (CharacterInfo)_businessObject; 
    public override void Initialize()
    {
        NameText.text = Character.FullName;
    }
}

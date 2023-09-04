using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterContainer : UIContainer
{
    public CharacterInfo Character => (CharacterInfo)_businessObject; 
    public override void Initialize()
    {
        return;
    }
}

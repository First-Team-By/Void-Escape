using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterInfoButton : MonoBehaviour
{
    private UIPartyBuildGameManager _infoConteiner;

    private void Start()
    {
        _infoConteiner = GameObject.FindObjectOfType<UIPartyBuildGameManager>();
    }

    public void OnPanelCharacterInfo()
    {
        _infoConteiner.InfoImageOn();
    }

    public void OffPanelCharacterInfo()
    {
        _infoConteiner.InfoImageOff();
    }
}

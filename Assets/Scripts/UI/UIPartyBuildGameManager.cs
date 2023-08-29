using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class UIPartyBuildGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    public List<UICharacterContainer> CharacterSlots { get; set; } = new List<UICharacterContainer>();

    public void InfoImageOn()
    {
        _infoPanel.SetActive(true);
    }

    public void InfoImageOff()
    {
        _infoPanel.SetActive(false);
    }
}

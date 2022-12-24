using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class UIPartyBuildGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    public List<UICharacterSlot> CharacterSlots { get; set; } = new List<UICharacterSlot>();

    public void InfoImageOn()
    {
        _infoPanel.SetActive(true);
    }

    public void InfoImageOff()
    {
        _infoPanel.SetActive(false);
    }
}

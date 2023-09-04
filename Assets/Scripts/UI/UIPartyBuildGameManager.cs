using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class UIPartyBuildGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    public List<UIDragCharacterContainer> CharacterSlots { get; set; } = new List<UIDragCharacterContainer>();

    public void InfoImageOn()
    {
        _infoPanel.SetActive(true);
    }

    public void InfoImageOff()
    {
        _infoPanel.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICharacterSlot : UIDragAndDrop
{
    [SerializeField] private CharacterInfo characterInfo;
    [SerializeField] private Button infoButton;
    [SerializeField] private Image _portrait;
    [SerializeField] private GameObject _serviceImagePanel;
    [SerializeField] private Text _characterName;

    public Text CharacterName => _characterName;

    private UIPartyBuildPosition lastSelectedPosition;

    private UIPartyBuildGameManager gameManager;

    public int CharacterId { get; set; }

    public GameObject ServiceImagePanel => _serviceImagePanel;

    public Image Portrait => _portrait;

    public CharacterInfo CharacterInfo
    {
        get { return characterInfo; }
        set { characterInfo = value; }
    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCanvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        gameManager = GameObject.FindObjectOfType<UIPartyBuildGameManager>();

        //infoButton.onClick.AddListener(gameManager.InfoImageOn);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        var currentRayCast = eventData.pointerCurrentRaycast;
        var partyBuildPosition = currentRayCast.gameObject.GetComponent<UIPartyBuildPosition>();
        if (partyBuildPosition != null)
        {
            lastSelectedPosition = partyBuildPosition;
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        var color = GetComponent<Image>().color;

        color.a = 0;

        GetComponent<Image>().color = color;

        ServiceImagePanel.SetActive(false);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        var color = GetComponent<Image>().color;

        color.a = 1;

        GetComponent<Image>().color = color;

        ServiceImagePanel.SetActive(true);

        lastSelectedPosition = null;
    }
}

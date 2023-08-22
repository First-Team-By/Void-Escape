using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICharacterSlot : UIDragAndDrop
{
    [SerializeField] private CharacterInfo _characterInfo;
    [SerializeField] private Button _infoButton;
    [SerializeField] private Image _portrait;
    [SerializeField] private GameObject _serviceImagePanel;
    [SerializeField] private Text _characterName;

    public GameObject OldParent { get; set; }

    private Transform _rootPanel;

    public Text CharacterName => _characterName;

    public CharacterInfo Character => _characterInfo;

    private UIPartyBuildPosition lastSelectedPosition;

    private UIPartyBuildGameManager gameManager;

    public int CharacterId { get; set; }

    public GameObject ServiceImagePanel => _serviceImagePanel;

    public Image Portrait => _portrait;

    public CharacterInfo CharacterInfo
    {
        get { return _characterInfo; }
        set { _characterInfo = value; }
    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCanvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        gameManager = GameObject.FindObjectOfType<UIPartyBuildGameManager>();

        _rootPanel = GameObject.Find("RootPanel").transform;

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

        Debug.Log("On begin drag");

        var color = GetComponent<Image>().color;

        color.a = 0;

        GetComponent<Image>().color = color;

        ServiceImagePanel.SetActive(false);



        OldParent = gameObject.transform.parent.gameObject;

        canvasGroup.alpha = 0.8f;

        canvasGroup.blocksRaycasts = false;

        gameObject.transform.SetParent(_rootPanel);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        Debug.Log("On end drag");

        var color = GetComponent<Image>().color;

        color.a = 1;

        GetComponent<Image>().color = color;

        ServiceImagePanel.SetActive(true);

        lastSelectedPosition = null;

        gameObject.transform.localPosition = Vector3.zero;


        if (gameObject.transform.parent == _rootPanel)
        {
            gameObject.transform.SetParent(OldParent.transform);

            gameObject.transform.localPosition = Vector3.zero;
        }

        canvasGroup.alpha = 1f;

        canvasGroup.blocksRaycasts = true;
    }
}

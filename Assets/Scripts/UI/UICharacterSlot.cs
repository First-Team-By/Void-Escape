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

    private RectTransform _scalePortret;

    private Color _gameObjectColor;

    private GameObject _medCapsule;

    public GameObject OldParent { get; set; }

    private Transform _contentMedCharPanel;

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

        _contentMedCharPanel = GameObject.Find("ContentMedCharPanel").transform;

        _scalePortret = gameObject.transform.GetChild(0).GetComponent<RectTransform>();

        _medCapsule = GameObject.Find("MedicineCapsule1");

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
        
        gameObject.GetComponent<Image>().color = color;

        ServiceImagePanel.SetActive(false);



        OldParent = gameObject.transform.parent.gameObject;

        canvasGroup.alpha = 1f;

        canvasGroup.blocksRaycasts = false;

        gameObject.transform.SetParent(_rootPanel);



        

        Vector3 newScale = new Vector3(1, 1);

        _scalePortret.localScale = newScale;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        Debug.Log("OnEnDrag");

        lastSelectedPosition = null;

        gameObject.transform.localPosition = Vector3.zero;


        if (gameObject.transform.parent == _rootPanel)
        {
            gameObject.transform.SetParent(OldParent.transform);

            gameObject.transform.localPosition = Vector3.zero;
        }

        if (_medCapsule.transform.childCount > 2)
        {
            gameObject.transform.SetParent(OldParent.transform);

            gameObject.transform.localPosition = Vector3.zero;
        }




        canvasGroup.alpha = 1f;

        canvasGroup.blocksRaycasts = true;



        var color = GetComponent<Image>().color;

        if (gameObject.transform.parent == _contentMedCharPanel)
        {
            color.a = 1;

            gameObject.GetComponent<Image>().color = color;

            ServiceImagePanel.SetActive(true);



            

            Vector3 newScale = new Vector3(1, 1);

            _scalePortret.localScale = newScale;
        }
        else
        {
            color.a = 0;

            gameObject.GetComponent<Image>().color = color;

            ServiceImagePanel.SetActive(false);



            

            Vector3 newScale = new Vector3(3, 3);

            _scalePortret.localScale = newScale;
        }
    }
}

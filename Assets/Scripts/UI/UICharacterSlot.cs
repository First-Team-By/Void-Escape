using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICharacterSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject characterPrefab;
    
    private RectTransform rectTransform;
    private Canvas mainCanvas;
    private CanvasGroup canvasGroup;
    private GameObject lastSelectedPosition;

    [SerializeField] private Button infoButton;
    [SerializeField] private Image _portrait;
    private UIPartyBuildGameManager gameManager;

    private Vector2 _originPosition;

    [SerializeField] private GameObject _serviceImagePanel;

    public GameObject ServiceImagePanel => _serviceImagePanel;

    public Image Portrait => _portrait;

    public GameObject CharacterPrefab
    {
        get { return characterPrefab; }
        set { characterPrefab = value; }
    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCanvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        gameManager = GameObject.FindObjectOfType<UIPartyBuildGameManager>();

        infoButton.onClick.AddListener(gameManager.InfoImageOn);
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;


        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        RaycastHit2D hit = Physics2D.Raycast(ray, Vector3.forward);
        if (hit.collider?.GetComponent<CharacterPosition>() ?? false)
        {
            lastSelectedPosition = hit.transform.gameObject;
            hit.transform.GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }
        else
        {
            if (lastSelectedPosition)
            {
                lastSelectedPosition.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _originPosition = transform.localPosition;

        var color = GetComponent<Image>().color;

        color.a = 0;

        GetComponent<Image>().color = color;

        ServiceImagePanel.SetActive(false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = _originPosition;

        var color = GetComponent<Image>().color;

        color.a = 1;

        GetComponent<Image>().color = color;

        ServiceImagePanel.SetActive(true);

        if (lastSelectedPosition)
        {
            lastSelectedPosition.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            var character = Instantiate(characterPrefab.gameObject, lastSelectedPosition.transform.position, Quaternion.identity);
            character.transform.SetParent(lastSelectedPosition.transform);

            character.GetComponent<Character>().Position = lastSelectedPosition.GetComponent<CharacterPosition>().Position;
            transform.gameObject.SetActive(false);
        }

        lastSelectedPosition = null;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMedDragDropCharacter : UIDragAndDrop
{
    public GameObject OldParent { get; set; }

    private Transform _rootPanel;

    [SerializeField] private Button infoButton;
    [SerializeField] private Image _portrait;
    [SerializeField] private GameObject _serviceImagePanel;
    [SerializeField] private Text _characterName;

    public Image Portrait => _portrait;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        canvasGroup = GetComponent<CanvasGroup>();

        mainCanvas = GetComponentInParent<Canvas>();

        _rootPanel = GameObject.Find("RootPanel").transform;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        OldParent = gameObject.transform.parent.gameObject;

        canvasGroup.alpha = 0.8f;

        canvasGroup.blocksRaycasts = false;

        gameObject.transform.SetParent(_rootPanel);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject.transform.parent == _rootPanel)
        {
            gameObject.transform.SetParent(OldParent.transform);

            gameObject.transform.localPosition = Vector3.zero;
        }

        canvasGroup.alpha = 1f;

        canvasGroup.blocksRaycasts = true;
    }
}

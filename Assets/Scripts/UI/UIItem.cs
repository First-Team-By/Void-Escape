using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private CanvasGroup _canvasGroup;

    private Canvas _mainCanvas;

    private RectTransform _rectTransform;

    [SerializeField] private SlotType _slotType;

    public SlotType SlotType => _slotType;

    public Equipment Equipment { get; set; }

    public GameObject OldParent { get; set; }

    private Transform _rootPanel;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        _mainCanvas = GetComponentInParent<Canvas>();

        _canvasGroup = GetComponent<CanvasGroup>();

        _rootPanel = GameObject.Find("RootPanel").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OldParent = transform.parent.gameObject;

        var slotTransform = _rectTransform.parent;

        slotTransform.SetAsLastSibling();

        _canvasGroup.blocksRaycasts = false;

        transform.SetParent(_rootPanel);
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;

        //_rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == _rootPanel)
        {
            transform.SetParent(OldParent.transform);
        }

        transform.localPosition = Vector3.zero;

        _canvasGroup.blocksRaycasts = true;
    }
}

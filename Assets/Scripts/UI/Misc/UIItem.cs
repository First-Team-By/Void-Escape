using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _icon;
    private CanvasGroup _canvasGroup;
    private Canvas _mainCanvas;
    private RectTransform _rectTransform;
    private Transform _rootPanel;

    public GameObject OldParent { get; set; }
    public Equipment Equipment { get; set; }
    public Image Icon => _icon;
    public SlotType SlotType => Equipment.SlotType;

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
        transform.position = eventData.position;
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

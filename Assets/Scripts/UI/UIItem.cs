using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _image;

    private CanvasGroup _canvasGroup;

    private Canvas _mainCanvas;

    private RectTransform _rectTransform;

    public GameObject OldParent { get; set; }

    private Transform _rootPanel;

    private Equipment _equipment;

    public Image Image => _image;

    public Equipment Equipment
    {
        get { return _equipment; }

        set{ _equipment = value; }
    }

    public SlotType SlotType
    {
        get { return Equipment.SlotType; }
    }

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

using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UIDragContainer : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] protected GameObject _backPanel;
    [SerializeField] protected GameObject _dragPanel;
    [SerializeField] protected Image _backImage; 
    [SerializeField] protected Image _dragImage;
    [SerializeField] private Vector2 _onDragScale; 

    protected RectTransform _rectTransform;
    protected Canvas _mainCanvas;
    protected CanvasGroup _canvasGroup;
    protected Transform _oldParent;
    protected Transform _rootPanel;

    private Vector2 _originPosition;

    public Transform OldParent
    {
        get => _oldParent;
        set => _oldParent = value;
    }

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _rootPanel = GameObject.Find("RootPanel").transform;

        Initialize();
    }

    public abstract void Initialize();

    public void ReturnToOldParent()
    {
        transform.SetParent(OldParent);
        transform.localPosition = Vector2.zero;

        if (OldParent.TryGetComponent<UIList>(out UIList uiList))
        {
            ToggleImagePanels(false);
        }
    }

    public void ToggleImagePanels(bool isDrag)
    {
        _backPanel.SetActive(!isDrag);
        _dragPanel.SetActive(isDrag);
    }

    public void SetPanelImages(Sprite backSprite, Sprite dragSprite)
    {
        _dragImage.sprite = dragSprite;
        _backImage.sprite = backSprite;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _originPosition = transform.localPosition;
        transform.localScale = _onDragScale;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = _originPosition;

        if (transform.parent == _rootPanel)
        {
            ReturnToOldParent();
        }
    }
}

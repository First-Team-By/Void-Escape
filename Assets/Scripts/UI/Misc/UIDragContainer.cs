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
    [SerializeField] protected GameObject _frontPanel;
    [SerializeField] protected Image _backImage; 
    [SerializeField] protected Image _frontImage;
    [SerializeField] private float _onDragScale = 1; 

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

    public Vector2 OnDragScale => Vector2.one * _onDragScale;

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
        ParentTo(OldParent);
    }

    public void ParentTo(Transform to)
    {
        if (to.TryGetComponent<IContainerHolder>(out IContainerHolder uiSlot))
        {
            transform.localScale = uiSlot.ContentScale;
        }
        
        transform.SetParent(to);
        transform.localPosition = Vector2.zero;
        ToggleImagePanels(!OldParent.TryGetComponent<UIList>(out UIList uiList));
    }

    public void ToggleImagePanels(bool isDrag)
    {
        _backPanel.SetActive(!isDrag);
        _frontPanel.SetActive(isDrag);
    }

    public void SetPanelImages(Sprite backSprite, Sprite dragSprite)
    {
        _frontImage.sprite = dragSprite;
        _backImage.sprite = backSprite;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _originPosition = transform.localPosition;
        transform.localScale = OnDragScale;
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

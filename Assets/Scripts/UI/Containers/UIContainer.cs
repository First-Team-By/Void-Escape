using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UIContainer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected GameObject _backPanel;
    [SerializeField] protected GameObject _frontPanel;
    [SerializeField] protected Image _backImage;
    [SerializeField] protected Image _frontImage;

    protected RectTransform _rectTransform;
    protected Canvas _mainCanvas;
    protected CanvasGroup _canvasGroup;
    protected Transform _rootPanel;
    protected Vector2 _originPosition;

    protected object _businessObject;
    public Action<UIContainer> ContainerClicked;

    public abstract void Initialize();

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

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _rootPanel = GameObject.Find("RootPanel").transform;

        Initialize();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ContainerClicked?.Invoke(this);
    }

    public virtual void SetBusinessObject(object obj)
    {
        _businessObject = obj;
    }
}

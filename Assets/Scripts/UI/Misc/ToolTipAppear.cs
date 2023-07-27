using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ToolTipAppear : MonoBehaviour , IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private GameObject _toolTipPanelPref;

    [SerializeField] private string _toolTip;

    private RectTransform _icon;

    private GameObject _toolTipPanel;

    private RectTransform _canvas;

    private TMP_Text _toolTipText;

    private Vector2 _toolTipPosition;

    private CanvasGroup _canvasGroup;


    public string ToolTipString 
    {
        set 
        { 
            _toolTip = value; 
        }
    }

    private void Start()
    {
        _canvas = GameObject.Find("UICanvas").GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(showToolTip());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();

        if (_toolTipPanel != null)
        {
            Destroy(_toolTipPanel);
        }
    }

    private IEnumerator showToolTip()
    {
        yield return new WaitForSeconds(1f);

        var mousePosition = Input.mousePosition;
        _toolTipPosition = mousePosition;

        var screenToLocal = mousePosition / _canvas.GetComponent<Canvas>().scaleFactor;

        _toolTipPanel = Instantiate(_toolTipPanelPref, _toolTipPosition, Quaternion.identity);
        _toolTipPanel.transform.SetParent(_canvas);
        

        _toolTipText = _toolTipPanel.transform.GetComponentInChildren<TMP_Text>();

        var background = _toolTipPanel.transform.GetChild(0).GetComponent<RectTransform>();

        _icon = background.transform.GetChild(1).GetComponent<RectTransform>();
        var padding = background.GetComponent<VerticalLayoutGroup>().padding;
        var iconSize = _icon.sizeDelta;

        ShowToolTip();

        _canvasGroup = _toolTipPanel.GetComponent<CanvasGroup>();
        _canvasGroup.blocksRaycasts = false;

        var backgroundSize = new Vector2(
            _toolTipText.preferredWidth + padding.right + padding.left,
            _toolTipText.preferredHeight + padding.top + padding.bottom
            );

        var overflow = new Vector2(
            screenToLocal.x + backgroundSize.x + iconSize.x / 2,
            screenToLocal.y + backgroundSize.y + iconSize.y / 2
            );

        if (overflow.x > _canvas.rect.width || overflow.y > _canvas.rect.height)
        {
            background.pivot = Vector2.one;
        }

        _toolTipPanel.transform.position = _toolTipPosition;
    }
    public virtual void ShowToolTip()
    {

        _toolTipText.text = _toolTip;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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

    private float _widthToolTipPanel;


    public string ToolTipString 
    {
        set { _toolTip = value; }
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

        _toolTipPosition = Input.mousePosition;
        _toolTipPanel = Instantiate(_toolTipPanelPref, _toolTipPosition, Quaternion.identity);
        _toolTipPanel.transform.SetParent(_canvas);

        _toolTipText = _toolTipPanel.transform.GetComponentInChildren<TMP_Text>();

        _icon = _toolTipPanel.transform.GetChild(1).GetComponent<RectTransform>();

        var back = _toolTipPanel.transform.GetChild(0).GetComponent<RectTransform>();

        ShowToolTip();
        
        _canvasGroup = _toolTipPanel.GetComponent<CanvasGroup>();
        _canvasGroup.blocksRaycasts = false;

        
        if (_toolTipPosition.x + _toolTipText.preferredWidth > _canvas.rect.width)
        {
            _widthToolTipPanel = _toolTipText.preferredWidth;

            _toolTipPosition.x -= _widthToolTipPanel;
        }
        if(_toolTipPosition.y + _toolTipText.preferredHeight > _canvas.rect.height)
        {
            _widthToolTipPanel = _toolTipText.preferredHeight;

            _toolTipPosition.y -= _widthToolTipPanel;
        }

        _toolTipPanel.transform.position = _toolTipPosition;

        _icon.transform.position = new Vector2(-30f, _toolTipText.preferredHeight + 10f) + _toolTipPosition;
    }

    public virtual void ShowToolTip()
    {

        _toolTipText.text = _toolTip;
    }
}

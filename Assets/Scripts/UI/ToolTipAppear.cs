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
    private GameObject _toolTipPanel;

    private Transform _canvas;

    private TMP_Text _toolTipText;

    private Vector3 _toolTipPosition;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Transform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(ShowToolTip("Команда'DoubleTap'\n-стреляет короткой очередью\nнесколько раз"));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();

        if (_toolTipPanel != null)
        {
            Destroy(_toolTipPanel);
        }
    }

    public IEnumerator ShowToolTip(string toolTipString)
    {
        yield return new WaitForSeconds(0.3f);

        _toolTipPosition = Input.mousePosition;
        _toolTipPanel = Instantiate(_toolTipPanelPref, _toolTipPosition, Quaternion.identity);
        _toolTipPanel.transform.SetParent(_canvas);

        _canvasGroup = _toolTipPanel.GetComponent<CanvasGroup>();
        _canvasGroup.blocksRaycasts = false;

        _toolTipText = _toolTipPanel.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        _toolTipText.text = toolTipString;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    protected RectTransform rectTransform;
    protected Canvas mainCanvas;
    protected CanvasGroup canvasGroup;

    private Vector2 _originPosition;

    public virtual void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _originPosition = transform.localPosition;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = _originPosition;
    }
}

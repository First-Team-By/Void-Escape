using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMedDragDropCharacter : UIDragAndDrop
{
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        canvasGroup = GetComponent<CanvasGroup>();

        mainCanvas = GetComponentInParent<Canvas>();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.8f;

        canvasGroup.blocksRaycasts = false;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;

        canvasGroup.blocksRaycasts = true;
    }
}

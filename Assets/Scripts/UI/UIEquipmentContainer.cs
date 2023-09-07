using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIEquipmentContainer : UIDragContainer
{
    public int CharacterId { get; set; }

    public Equipment Equipment => (Equipment)_businessObject;

    public override void Initialize()
    {
        return;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        ToggleImagePanels(true);

        Debug.Log("On begin drag");
        OldParent = transform.parent;

        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = false;

        transform.SetParent(_rootPanel);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        Debug.Log("OnEnDrag");

        transform.localPosition = Vector3.zero;
        _canvasGroup.alpha = 1f;

        _canvasGroup.blocksRaycasts = true;
    }
}

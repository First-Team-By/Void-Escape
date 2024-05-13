using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragCharacterContainer : UIDragContainer, IPointerClickHandler
{
    public int CharacterId { get; set; }
    [SerializeField] private TMP_Text NameText;
    public CharacterInfo Character => (CharacterInfo)_businessObject;

    public override void Initialize()
    {
        NameText.text = Character.FullName;
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

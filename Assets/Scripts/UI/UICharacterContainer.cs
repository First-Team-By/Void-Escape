using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICharacterContainer : UIDragContainer, IPointerClickHandler
{
    [SerializeField] private CharacterInfo _characterInfo;

    public event Action<CharacterInfo> CharacterClicked;

    public int CharacterId { get; set; }

    public CharacterInfo Character
    {
        get => _characterInfo;
        set => _characterInfo = value;
    }

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

    public void OnPointerClick(PointerEventData eventData)
    {
        print("Character clicked");
        CharacterClicked?.Invoke(_characterInfo);
    }
}

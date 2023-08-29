using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICharacterContainer : UIDragContainer
{
    [SerializeField] private CharacterInfo _characterInfo;

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

        

        //if (_medCapsule.transform.childCount > 2)
        //{
        //    transform.SetParent(OldParent.transform);
        //    transform.localPosition = Vector3.zero;
        //}
        _canvasGroup.alpha = 1f;

        _canvasGroup.blocksRaycasts = true;
        //var color = GetComponent<Image>().color;

        //if (transform.parent == _contentMedCharPanel)
        //{
        //    color.a = 1;
        //    GetComponent<Image>().color = color;
        //    ServiceImagePanel.SetActive(true);
        //    Vector3 newScale = new Vector3(1, 1);
        //    _scalePortrait.localScale = newScale;
        //}
        //else
        //{
        //    color.a = 0;
        //    GetComponent<Image>().color = color;
        //    ServiceImagePanel.SetActive(false);
        //    Vector3 newScale = new Vector3(3, 3);
        //    _scalePortrait.localScale = newScale;
        //}
    }

    
}

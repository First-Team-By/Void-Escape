using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPartyBuildPosition : UISlot, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _positionImage;
    [SerializeField] private int position;
    public int Position => position;
    public CharacterInfo Character { get; set; }
    public bool IsFree => Character == null;
    public override Type ContainerType => typeof(UICharacterContainer);

    void Start()
    {
        //partyManager = GameObject.FindObjectOfType<UIPartyBuildGameManager>();
    }

    public override void ProcessDrop(UIDragContainer container)
    {
        Character = (container as UICharacterContainer).Character;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsFree)
        {
            _positionImage.color = new Color(1, 0, 0, 1);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _positionImage.color = new Color(0, 1, 0, 1);
    }
}

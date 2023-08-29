using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public abstract class UISlot : MonoBehaviour, IDropHandler
{
    public abstract Type ContainerType { get; }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<UIDragContainer>(out UIDragContainer container))
        {
            //RefreshCurrentGroup(uiPosition.Position);
            if (container.GetType() != ContainerType)
            {
                return;
            }

            container.transform.SetParent(transform);
            container.transform.localPosition = Vector2.zero;

            ProcessDrop(container);
        }
    }

    public abstract void ProcessDrop(UIDragContainer container);

    //private void RefreshCurrentGroup(int position)
    //{
    //    var currentCharacter =
    //            Global.currentGroup.CurrentCharacterInfos.FirstOrDefault(x => x.Position == position);

    //    Global.currentGroup.CurrentCharacterInfos.Remove(currentCharacter);
    //}
}

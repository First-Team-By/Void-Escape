using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMedCapsuleSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var dragChar = eventData.pointerDrag;

            dragChar.transform.SetParent(gameObject.transform);

            dragChar.GetComponent<RectTransform>().localPosition = Vector2.zero;
        }
    }
}

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
            eventData.pointerDrag.transform.SetParent(gameObject.transform);

            eventData.pointerDrag.GetComponent<RectTransform>().localPosition = Vector2.zero;
        }
    }
}

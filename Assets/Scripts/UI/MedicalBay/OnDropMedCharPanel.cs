using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDropMedCharPanel : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject _medCharPanelContent;

    public void OnDrop(PointerEventData eventData)
    {
        var dragChar = eventData;

        if(dragChar.pointerDrag != null)
        {
            dragChar.pointerDrag.transform.SetParent(_medCharPanelContent.transform);

            dragChar.pointerDrag.GetComponent<RectTransform>().localPosition = Vector2.zero;
        }
    }
}

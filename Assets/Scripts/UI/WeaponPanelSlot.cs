using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponPanelSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject _contentWeaponPanel;

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;

        otherItemTransform.SetParent(_contentWeaponPanel.transform);
    }
}

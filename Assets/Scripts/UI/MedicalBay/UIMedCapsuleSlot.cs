using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMedCapsuleSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject _cplPanel;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var dragChar = eventData.pointerDrag;

            dragChar.transform.SetParent(gameObject.transform);

            dragChar.GetComponent<RectTransform>().localPosition = Vector2.zero;

            _cplPanel.SetActive(true);
        }
    }
}

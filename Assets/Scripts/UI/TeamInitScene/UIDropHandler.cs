using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

public class UIDropHandler : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Action<PointerEventData> OnDropEvent, OnPointerEnterEvent, OnPointerExitEvent;
    public Image Container { get; private set; }
    void Start()
    {
        Container = GetComponent<Image>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        OnDropEvent?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitEvent?.Invoke(eventData);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterEvent?.Invoke(eventData);
    }
}

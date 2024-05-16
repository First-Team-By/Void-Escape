using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public abstract class UISlot : MonoBehaviour, IDropHandler, IContainerHolder
{
    [SerializeField] private float _contentScale = 1;
    private UIDragContainer _container;

    public Vector2 ContentScale => Vector2.one * _contentScale;
    public abstract Type ContainerType { get; }
    public UIDragContainer Container
    {
        get => _container;
        set => _container = value;
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<UIDragContainer>(out UIDragContainer container))
        {
            if (!IsAcceptable(container))
            {
                return;
            }

            container.ParentTo(transform);
            container.transform.localScale = ContentScale;

            ProcessDrop(container);
        }
    }

    protected virtual bool IsAcceptable(UIDragContainer container)
    {
        bool result = container.GetType() == ContainerType;
        return result;
    }

    public abstract void ProcessDrop(UIDragContainer container);
}

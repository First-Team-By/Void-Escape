using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UIDragContainer : UIContainer, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float _onDragScale = 1;
    protected Transform _oldParent;

    public Transform OldParent
    {
        get => _oldParent;
        set => _oldParent = value;
    }

    public Vector2 OnDragScale => Vector2.one * _onDragScale;

    public virtual void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _originPosition = transform.localPosition;
        transform.localScale = OnDragScale;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = _originPosition;

        if (transform.parent == _rootPanel)
        {
            ReturnToOldParent();
        }
    }

    public void ReturnToOldParent()
    {
        ParentTo(OldParent);
    }

    public void ParentTo(Transform to)
    {
        if (to.TryGetComponent<IContainerHolder>(out IContainerHolder holder))
        {
            transform.localScale = holder.ContentScale;
        }

        if (to.TryGetComponent<UISlot>(out UISlot uiSlot))
        {
            uiSlot.Container = this;
        }

        transform.SetParent(to);
        transform.localPosition = Vector2.zero;
        ToggleImagePanels(!transform.parent.TryGetComponent<UIList>(out UIList uiList));
    }
}

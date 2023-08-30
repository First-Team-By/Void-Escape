using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UIListController<T> : UIList
{
    [SerializeField] private GameObject _objectContainerPrefab;
    [SerializeField] private bool isDraggable = true;

    public abstract List<T> Objects { get; }

    private void OnEnable()
    {
        foreach (Transform item in transform.GetComponentInChildren<Transform>())
        {
            Destroy(item.gameObject);
        }

        foreach (var obj in Objects)
        {
            var objectContainer = GameObject.Instantiate(_objectContainerPrefab.gameObject) as GameObject;
            var uiDragContainer = objectContainer.GetComponent<UIDragContainer>();

            BindObject(uiDragContainer, obj);
            objectContainer.transform.SetParent(transform, false);

            uiDragContainer.enabled = isDraggable;
        }
    }

    public abstract void BindObject(UIDragContainer container, T obj);
}

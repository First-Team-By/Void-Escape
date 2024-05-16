using System.Collections.Generic;
using UnityEngine;

public abstract class UIListController<T> : UIList
{
    [SerializeField] protected GameObject _objectContainerPrefab;

    public abstract List<T> Objects { get; }

    private void OnEnable()
    {
        FillList();
    }

    protected virtual void FillList()
    {
        foreach (Transform item in transform.GetComponentInChildren<Transform>())
        {
            Destroy(item.gameObject);
        }

        foreach (var obj in Objects)
        {
            var objectContainer = Instantiate(_objectContainerPrefab.gameObject);
            var uiContainer = objectContainer.GetComponent<UIContainer>();

            BindObject(uiContainer, obj);
            objectContainer.transform.SetParent(transform, false);
        }
        Init();
    }

    abstract protected void Init();
    public virtual void BindObject(UIContainer container, T obj)
    {
        container.SetBusinessObject(obj);
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UIListController<T> : UIList
{
    [SerializeField] private GameObject _objectContainerPrefab;

    public abstract List<T> Objects { get; }

    private void OnEnable()
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

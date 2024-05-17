using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UIStorgePositionListController : UIListController<StoragePosition>
{
    // protected abstract GameObject _itemContainerPrefab { get; }
    [SerializeField] protected float _contextScale = 1;
    [SerializeField] protected float _contextOnDragScale = 1;
    private Vector2 ContextScale => Vector2.one * _contextScale;
    protected abstract Inventory _parentInventory { get; }
    protected List<UIStoragePositionContainer> _uIStoragePositionContainers = new List<UIStoragePositionContainer>();
    public UIStoragePositionContainer GetStoragePositionContainer(Item item)
    {
        return _uIStoragePositionContainers.FirstOrDefault(x => x.StoragePosition.Item.GetType() == item.GetType());
    }

    public StoragePosition AddItem(Item item)
    {
        return _parentInventory.AddItem(item);
    }
    public void AddNewItem(Item item)
    {
        AddStoragePositionContainer(AddItem(item));
    }

    public void DropItemContainer(Item item)
    {
        var existingStoragePositionContainer = GetStoragePositionContainer(item);
        if (existingStoragePositionContainer != null)
        {
            AddItem(item);
        }
        else
        {
            AddNewItem(item);
        }
    }

    public void AddStoragePositionContainer(StoragePosition storagePosition)
    {
        var positionContainer = Instantiate(Global.CommonPrefabs.StoragePositionContainer).GetComponent<UIStoragePositionContainer>();
        var uiContainer = positionContainer.GetComponent<UIContainer>();
        BindObject(uiContainer, storagePosition);

        positionContainer.SetContentScale(ContextScale, _contextOnDragScale);
        
        positionContainer.CreateItemContainer(storagePosition.Item);

        positionContainer.transform.localScale = ContentScale;
        
        positionContainer.transform.SetParent(transform, false);
        _uIStoragePositionContainers.Add(positionContainer.GetComponent<UIStoragePositionContainer>());
    }

    protected override void FillList()
    {
        foreach (Transform item in transform.GetComponentInChildren<Transform>())
        {
            Destroy(item.gameObject);
        }

        foreach (var obj in Objects)
        {
            AddStoragePositionContainer(obj);
        }
        Init();
    }



    protected override void Init()
    {
        return;
    }
}

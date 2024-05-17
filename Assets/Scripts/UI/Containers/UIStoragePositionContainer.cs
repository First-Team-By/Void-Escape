using TMPro;
using UnityEngine;

public class UIStoragePositionContainer : UIContainer
{
    public Transform ItemParent;
    [SerializeField] TMP_Text AmountText;
    protected Vector3 _contentScale = Vector2.one;
    protected float _contentOnDragScale = 0;
    public StoragePosition StoragePosition => (StoragePosition)_businessObject;

    public void SetAmount()
    {
        AmountText.text = StoragePosition.CaptionAmount;
    }

    public override void SetBusinessObject(object obj)
    {
        base.SetBusinessObject(obj);
        StoragePosition.AmountChanged += SetAmount;
    }
    public void CreateItemContainer(Item item)
    {
        var itemContainer = ItemFactory.CreateItem(item, ItemParent);
        itemContainer.transform.localScale = _contentScale;
        if (_contentOnDragScale > 0) 
        {
            itemContainer.SetOnDragScale(_contentOnDragScale);
        }
        SetAmount();
    }

    public void SetContentScale(Vector2 contentScale, float onDragScale = 0)
    {
        _contentScale = contentScale;
        _contentOnDragScale = onDragScale;
    }

    public override void Initialize()
    {
        
    }
}

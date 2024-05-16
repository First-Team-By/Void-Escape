using TMPro;
using UnityEngine;

public class UIStoragePositionContainer : UIContainer
{
    public Transform ItemParent;
    [SerializeField] TMP_Text AmountText;
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
        ItemFactory.CreateItem(item, ItemParent);
        SetAmount();
    }

    public override void Initialize()
    {
        
    }
}

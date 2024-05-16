using System;

public class StoragePosition 
{
    public int ID {  get; set; }
    protected int _amount;
    public Item Item { get; private set; }
    public int Amount
    {
        get { return _amount; }
        set 
        {
            _amount = value;
            AmountChanged?.Invoke();
        }
    }

    public bool IsInfinite => Item.IsInfinite;
    private Inventory _parentInventory;

    public event Action AmountChanged;
    public string CaptionAmount
    {
        get
        {
            return IsInfinite ? "∞" : Amount.ToString();
        }
    }
    public StoragePosition(Item item, Inventory parentInventory)
    {
        Item = item;
        Amount = 1;
        _parentInventory = parentInventory;
        ID = Global.GlobalID++;
    }

    public void RemoveItem()
    {
        if (_parentInventory != null)
        {
            _parentInventory.RemoveItem(Item) ;
        }

    }
}

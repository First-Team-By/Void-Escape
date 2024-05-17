using UnityEngine;

public abstract class Item
{
    [SerializeField] private SlotType _slotType;
    public SlotType SlotType
    {
        get { return _slotType; }
        set { _slotType = value; }
    }

    public bool IsInfinite { get; set; } = false;
    public Sprite Icon { get; set; }
    protected abstract string IconName { get; }
    protected virtual void Init()
    {
        Icon = Resources.Load<Sprite>("Sprites/Items/" + IconName);
    }
    protected Item()
    {
        Init();
    }

}

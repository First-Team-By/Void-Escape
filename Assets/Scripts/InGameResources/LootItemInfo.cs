using System;
using static UnityEditor.Progress;


public class LootItemInfo
{
    public Type Type { get; }
    public float Rarity { get; }
    public LootItem CreateLootItem(int amount = 1)
    {
       return new LootItem(Type, amount);
    }
    public LootItemInfo(Type type, float rarity = 1f)
    {
        Type = type;
        Rarity = rarity;
    }
}

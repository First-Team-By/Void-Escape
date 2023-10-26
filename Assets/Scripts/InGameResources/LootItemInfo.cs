using System;
using static UnityEditor.Progress;


public class LootItemInfo
{
    public Type Type { get; }
    public float Weight { get; }
    public LootItem CreateLootItem(int amount = 1)
    {
       return new LootItem(Type, amount);
    }
    public LootItemInfo(Type type, float weight = 1f)
    {
        Type = type;
        Weight = weight;
    }
}

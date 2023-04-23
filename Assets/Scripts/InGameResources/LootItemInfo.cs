using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LootItemInfo
{
    public Type Type { get; }
    public float Rarity { get; }
    public LootItemInfo(Type type, float rarity = 1f)
    {
        Type = type;
        Rarity = rarity;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ConditionInfo
{
    public ConditionInfo(float chance, int duration, float damage)
    {
        Chance = chance;
        Duration = duration;
        Damage = damage;
    }
    public float Chance { get; set; }
    public int Duration { get; set; }
    public float Damage { get; set; }
}
public class Conditioning
{
    public ConditionInfo Bleeding { get; set; }
    public bool CanGetBleed => Bleeding.Chance > 0;

    public void SetBleeding(float chance, int duration, float damage)
    {
        Bleeding = new ConditionInfo(chance, duration, damage);
    }
}


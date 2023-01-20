using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Timeline;

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
    public ConditionInfo Poisoning { get; set; }
    public ConditionInfo Arsoning { get; set; }
    public bool CanGetArson => Arsoning != null && Arsoning.Chance > 0;
    public bool CanGetBleed => Bleeding != null && Bleeding.Chance > 0;
    public bool CanGetPoison => Poisoning != null && Poisoning.Chance > 0;

    public void SetBleeding(float chance, int duration, float damage)
    {
        Bleeding = new ConditionInfo(chance, duration, damage);
    }

    public void SetPoisoning(float chance, int duration, float damage)
    {
        Poisoning = new ConditionInfo(chance, duration, damage);
    }

    public void SetArsoning(float chance, int duration, float damage)
    {
        Arsoning = new ConditionInfo(chance, duration, damage);
    }
}


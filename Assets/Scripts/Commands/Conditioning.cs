﻿public class ConditionInfo
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
    public ConditionInfo Burning { get; set; }
    public ConditionInfo Fearing { get; set; }
    public bool CanGetBurn => Burning != null && Burning.Chance > 0;
    public bool CanGetBleed => Bleeding != null && Bleeding.Chance > 0;
    public bool CanGetPoison => Poisoning != null && Poisoning.Chance > 0;
    public bool CanGetFear => Fearing != null && Fearing.Chance > 0;

    public void SetBleeding(float chance, int duration, float damage)
    {
        Bleeding = new ConditionInfo(chance, duration, damage);
    }

    public void SetPoisoning(float chance, int duration, float damage)
    {
        Poisoning = new ConditionInfo(chance, duration, damage);
    }

    public void SetBurning(float chance, int duration, float damage)
    {
        Burning = new ConditionInfo(chance, duration, damage);
    }

    public void SetFearing(float chance, int duration = 1, float damage = 0)
    {
        Fearing = new ConditionInfo(chance, duration, damage);
    }
}


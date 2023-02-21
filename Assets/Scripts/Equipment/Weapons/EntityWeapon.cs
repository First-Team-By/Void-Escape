using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Blade,
    Pistol
}

public abstract class EntityWeapon : Equipment
{
    public WeaponType Type { get; set; }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EntityConditions
{
    public (int duration, float bleedDamage) bleeding;
    public (int duration, float poisonDamage) poisoning;
    public (int duration, float arsonDamage) burning;
    public (bool isDeseased, EntityDesease desease) desease;
    public bool isStunned;

    public bool IsBleeding => bleeding.duration > 0;
    public bool IsPoisoned => poisoning.duration > 0;
    public bool IsBurning => burning.duration > 0;
    //public bool isAffected;
    //public bool isReinforced;
    //public bool isDiminished;
    public void DropTemporaryConditions()
    {
        bleeding.duration = 0;
        poisoning.duration = 0;
        burning.duration = 0;
    }
}

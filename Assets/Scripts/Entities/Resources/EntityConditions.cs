using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EntityConditions
{
    public (int duration, float bleedDamage) bleeding;
    public (bool isPoisoned, int duration, float poisonDamage) poisoned;
    public (bool isDeseased, EntityDesease desease) desease;
    public bool isStunned;

    public bool IsBleeding => bleeding.duration > 0;
    //public bool isAffected;
    //public bool isReinforced;
    //public bool isDiminished;

}

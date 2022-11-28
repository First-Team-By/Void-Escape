using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EntityConditions
{
    public (bool isPoisoned, int duration, float poisonDamage) poisoned;
    public (bool isBleeding, int duration, float bleedDamage) bleeding;
    public (bool isDeseased, EntityDesease desease) desease;
    public bool isStunned;
    public bool isAffected;
    public bool isReinforced;
    public bool isDiminished;
}

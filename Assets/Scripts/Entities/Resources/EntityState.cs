using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EntityState
{
    public (bool isPoisoned, int duration, float poisonDamage) poisonedState;
    public (bool isBleeding, int duration, float bleedDamage) bleedingState;
    public (bool isDeseased, EntityDesease desease) deseaseState;
    public bool isStunned;
    public bool isAffected;
    public bool isReinforced;
    public bool isDiminished;
}

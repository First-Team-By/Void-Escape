using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntityConditions
{
    public (int duration, float bleedDamage) bleeding;
    public (int duration, float poisonDamage) poisoning;
    public (int duration, float burningDamage) burning;
    public (bool isDeseased, EntityDesease desease) desease;
    public int stunned;
    public bool IsBleeding => bleeding.duration > 0;
    public bool IsPoisoned => poisoning.duration > 0;
    public bool IsBurning => burning.duration > 0;
    public bool IsStunned => stunned > 0;

    public int brokenArm;
    public int brokenLeg;

    public bool ArmBroken => brokenArm > 0;
    public bool LegBroken => brokenLeg > 0;


    public List<EntityMutilation> Mutilations = new List<EntityMutilation> ();

    public void AddMutilation(EntityMutilation mutilation)
    {
        if (!Mutilations.Contains (mutilation))
            Mutilations.Add(mutilation);
    }

    public void RemoveMutilation(EntityMutilation mutilation)
    {
        Mutilations.Remove(mutilation);
    }

    public void ClearMutilation()
    {
        Mutilations.Clear();
    }

    public void DropTemporaryConditions()
    {
        bleeding.duration = 0;
        poisoning.duration = 0;
        burning.duration = 0;
    }

    public void DecreaseConstantCondition()
    {
        if (brokenArm > 0)
        {
            brokenArm--;
        }

        if (brokenLeg > 0)
        {
            brokenLeg--;
            if (Random.Range(0, 1) <= 0.2f)
            {
                AddMutilation(new Limping());   //Хромота
            }
        }
    }

    public void ClearConstantCondition() 
    {
        brokenArm = 0;
        brokenLeg = 0;
    }
}

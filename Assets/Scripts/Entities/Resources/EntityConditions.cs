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
        }
    }

    public void ClearConstantCondition() 
    {
        brokenArm = 0;
        brokenLeg = 0;
    }
}

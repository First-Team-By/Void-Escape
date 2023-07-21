public class Limping : EntityMutilation     //Хромота
{
    public override EntityCharacteristics Affect(EntityCharacteristics characteristics)
    {
        characteristics.Initiative = (int)(characteristics.Initiative * 0.7);
        characteristics.Defence = (int)(characteristics.Defence * 0.7);
        characteristics.EvadeChance = (int)(characteristics.EvadeChance * 0.5);

        return characteristics;
    }

    public Limping()
    {
        Name = "Хромота";
        CostToHeal.Energy = 100;
        CostToHeal.Medicine = 200;
        CostToHeal.Metal = 10;
    }
}


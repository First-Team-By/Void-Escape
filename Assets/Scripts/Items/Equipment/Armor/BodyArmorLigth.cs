public class BodyArmorLigth : EntityArmor
{
    public BodyArmorLigth() : base()
    {
        Type = ArmorType.Light;

        SlotType = SlotType.Armor;

        _resistances.BleedResistance = 10;

        _resistances.DamageResistance = 5;
    }

    protected override string IconName => "BodyArmorLigth_1.1";

}


public class MedicationSet : ResourceItem
{
	protected override string IconName => "Medicine/medication-set-icon_sprite";
	
	public MedicationSet()
	{
		Resources.Medicine = 20;
	}
}
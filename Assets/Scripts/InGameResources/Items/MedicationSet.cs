public class MedicationSet : ResourceItem
{
	protected override string IconName => throw new System.NotImplementedException();
	
	public MedicationSet()
	{
		Resources.Medicine = 20;
	}
}
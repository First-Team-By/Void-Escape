public class ElectricalSpareParts : ResourceItem
{
	protected override string IconName => throw new System.NotImplementedException();
	
	public ElectricalSpareParts()
	{
		Resources.Electronics = 20;
	}
}
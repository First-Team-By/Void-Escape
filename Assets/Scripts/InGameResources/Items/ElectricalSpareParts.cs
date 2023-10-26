public class ElectricalSpareParts : ResourceItem
{
	protected override string IconName => "Electronics/electric-spare-set-icon_sprite";
	
	public ElectricalSpareParts()
	{
		Resources.Electronics = 20;
	}
}
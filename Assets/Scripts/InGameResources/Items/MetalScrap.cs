public class MetalScrap : ResourceItem
{
	protected override string IconName => "Metal/metal-scrap-icon_sprite";
	
	public MetalScrap()
    {
        Resources.Metal = 20;
    }
}
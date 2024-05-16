using System.Collections.Generic;

public class UIAllCharactersListController : UIListController<CharacterInfo>
{
    public override List<CharacterInfo> Objects => Global.AllCharacters.CharacterInfos;

    public override void BindObject(UIContainer container, CharacterInfo obj)
    {
        base.BindObject(container, obj);

        container.SetPanelImages(obj.FullFaceSprite, obj.FullFaceSprite);
    }

    protected override void Init()
    {
        return;
    }
}

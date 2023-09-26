public class CollectItemQuest : Quest
{
    public override string Title => "Нахождение предмета";
    public override string Description => "Найдите предмет";
    public override QuestType Type { get; set; }

    public override void Initialize(MapInfo mapInfo)
    {
        throw new System.NotImplementedException();
    }
}

public class ExplorationQuest : Quest
{
    public override string Title => "Исследование территории";
    public override string Description => "Свободная охота";
    public override QuestType Type { get; set; }

    public override void Initialize(MapInfo mapInfo)
    {
        
    }
}

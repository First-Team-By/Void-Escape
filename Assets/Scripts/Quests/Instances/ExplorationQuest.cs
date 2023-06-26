public class ExplorationQuest : Quest
{
    public override string Title => "Исследование территории";
    public override string Description => "Пройдите какое-то количество комнат";
    public override QuestType Type { get; set; }
}

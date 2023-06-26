using System;

public class KillMonsterQuest : Quest
{
    private int monstersAmount;
    private Type monsterType;
    public override string Title => "Убийство монстров";
    public override string Description => "Убейте 5 монстров";
    public override QuestType Type { get; set; }
}

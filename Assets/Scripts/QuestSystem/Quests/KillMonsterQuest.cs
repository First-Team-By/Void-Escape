using System;

public class KillMonsterQuest : Quest
{
    private int monstersAmount;
    private Type monsterType;
    public override string Title => $"Kill {monstersAmount} monster(s) of type {monsterType}";
    public override string Description => "";
    public override QuestDifficulty Difficulty { get; }

}

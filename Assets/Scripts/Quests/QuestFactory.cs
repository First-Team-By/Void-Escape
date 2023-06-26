public class QuestFactory
{
    public Quest GetQuest()
    {
        return new KillMonsterQuest();
    }
}
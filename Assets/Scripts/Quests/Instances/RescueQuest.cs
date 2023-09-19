using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueQuest : Quest
{
    public override string Title => "Спасение человека";

    public override string Description => "Спасти персонажа";

    public override QuestType Type { get; set; }
}

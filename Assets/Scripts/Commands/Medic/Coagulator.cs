using System.Collections.Generic;
using System.Linq;

public class Coagulator : CharacterCommand
{
    public override string IconName => "Medic/command_coagulator_sprite";
    public override string EffectName => "effect_coagulator_sprite";
    public Coagulator()
    {
        IsEnabled = CoagulatorEnabled;

        SelfPositions = new List<int>() { 4, 5 };

        Name = "<size=30><color=#ffa500ff>Коагулятор</color></size>";

        Description = "\nСнимает <color=#ff0000ff>Кровотечение</color>";

        FullDescription = Name + "\n" + Description;
    }

    public override CommandResult Execute(BattleCommandExecuteInfo executeInfo)
    {
        var result = base.Execute(executeInfo);
        var target = executeInfo.Targets.FirstOrDefault();
        result.TargetStates.Add(target.Position, target.StopBleeding(Effect));
        result.Actor = executeInfo.Actor;
        //result.ActorPose = EntityPose.AttackPose;
        result.ActorPoseName = PosesConst.Buffing;

        return result;
    }

    public override bool IsAvaliable(EntityInfo entity)
    {
        if (entity is CharacterInfo)
        {
            return (entity as CharacterInfo).Device?.Type == DeviceType.FirstAidKit;
        }

        return true;
    }

    public override List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targetPositions)
    {
        return targetPositions.Where(x => x.Position < 6 && x.Conditions.IsBleeding).ToList();
    }

    private bool CoagulatorEnabled(EntityInfo entity)
    {
        return SelfPositions.Contains(entity.Position);
    }
}

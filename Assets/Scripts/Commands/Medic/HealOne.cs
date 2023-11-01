using System.Collections.Generic;
using System.Linq;

public class HealOne : CharacterCommand
{
    private float healthAddition = 100;
    public HealOne()
    {
        IsEnabled = HealOneEnabled;

        SelfPositions = new List<int>() { 4, 5 };

        Name = "<size=30><color=#ffa500ff>�������</color></size>";

        Description = "\n����� ������ ��������\n������� ������ ������";

        FullDescription = Name + "\n" + Description;
    }

    public override string IconName => "Medic/command_healone_sprite";
    public override string EffectName => "effect_healone_sprite";
    public override List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targetPositions)
    {
        return targetPositions.Where(x => x.Position < 6 && !x.OnDeathDoor).ToList();
    }

    public override List<int> GetSelectedTargets(int targetPosition)
    {
        return base.GetSelectedTargets(targetPosition);
    }

    private bool HealOneEnabled(EntityInfo entity)
    {
        return SelfPositions.Contains(entity.Position);
    }

    public override CommandResult Execute(BattleCommandExecuteInfo executeInfo)
    {
        var result = base.Execute(executeInfo);
        var target = executeInfo.Targets.FirstOrDefault();
        result.TargetStates.Add(target.Position, target.GetHealth(healthAddition, Effect));
        result.Actor = executeInfo.Actor;
        //result.ActorPose = EntityPose.AttackPose;
        result.ActorPoseName = Poses.Buffing;

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
}

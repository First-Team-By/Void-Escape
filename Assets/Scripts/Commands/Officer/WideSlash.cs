using System.Collections.Generic;
using System.Linq;

public class WideSlash : CharacterCommand
{
    public override string IconName => "Officer/command_wideslash_sprite";

    public override string EffectName => "effect_slash_sprite";
    public WideSlash()
    {
        damage = 10;

        Name = "<size=30><color=#ffa500ff>Широкий замах</color></size>";

        Description = "\n<color=#0000ffff>(Персонаж обязан находиться в первой линии.)</color>\nНаносит урон одной из ближайших целей и цели справа от нее.";

        FullDescription = Name + "\n" + Description;

        Conditioning.SetBleeding(0.3f, 2, 3);
    }
    public override bool IsAvaliable(EntityInfo entity)
    {
        if (entity is CharacterInfo)
        {
            return (entity as CharacterInfo).Weapon != null && (entity as CharacterInfo).Weapon.Type == WeaponType.Blade;
        }

        return true;
    }

    public override List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targets)
    {
        if (selfPosition > 3)
        {
            return new List<EntityInfo>();
        }

        if (selfPosition == 1)
        {
            return targets.Where(x => x.Position == 6 || x.Position == 7 && !x.OnDeathDoor).ToList();
        }
        if (selfPosition == 3)
        {
            return targets.Where(x => x.Position == 7 || x.Position == 8 && !x.OnDeathDoor).ToList();
        }

        return targets.Where(x => x.Position < 9 && x.Position > 5 && !x.OnDeathDoor).ToList();
    }

    public override List<int> GetSelectedTargets(int targetPosition)
    {
        if (targetPosition == 6)
        {
            return new List<int>() { 6, 7 };
        }

        if (targetPosition == 7)
        {
            return new List<int>() { 7, 8 };
        }

        return new List<int>() { 8 };

    }

    public override CommandResult Execute(BattleCommandExecuteInfo executeInfo)
    {
        var result = base.Execute(executeInfo);
        foreach (var target in executeInfo.Targets)
        {
            var targetState = AttackResolver.ResolveAttack(damage, executeInfo.Actor, target, Conditioning);
            result.TargetStates.Add(target.Position, targetState);
        }

        result.ActorPoseName = PosesConst.BladeSlash;
        return result;
    }


}

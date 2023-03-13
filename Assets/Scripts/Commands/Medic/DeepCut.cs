using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DeepCut : CharacterCommand
{
    public override string IconName => "deepcut_sprite";
    public override string EffectName => "deepcuteffect_sprite";

    public DeepCut()
    {
        SelfPositions = new List<int>() { 1, 2, 3 };

        Name = "Double tap";

        damage = 10;

        Conditioning.SetBleeding(.5f, 3, 3);
    }
    public override CommandResult Execute(EntityBase actor, List<EntityBase> targets)
    {
        var result = new CommandResult();
        foreach (var target in targets)
        {
            result.TargetStates.Add(target.Position, target.TakeDamage(damage, actor.EntityChars, Effect, Conditioning));
        }
        result.Actor = actor;
        //result.ActorPose = EntityPose.AttackPose;
        result.ActorPoseName = Poses.BladeStab;

        return result;
    }

    public override bool IsAvaliable(EntityBase entity)
    {
        if (entity is Character)
        {
            return (entity as Character).Weapon?.Type == WeaponType.Scalpel;
        }

        return false;
    }

    public override List<EntityBase> GetAvaliableTargets(int selfPosition, List<EntityBase> targetPositions)
    {
        if (selfPosition > 3)
        {
            return new List<EntityBase>();
        }
        if (selfPosition == 1)
        {
            return targetPositions.Where(x => x.Position == 6 || x.Position == 7 && !x.OnDeathDoor).ToList();
        }
        if (selfPosition == 3)
        {
            return targetPositions.Where(x => x.Position == 7 || x.Position == 8 && !x.OnDeathDoor).ToList();
        }

        return targetPositions.Where(x => x.Position < 9 && x.Position > 5 && !x.OnDeathDoor).ToList();
    }
}

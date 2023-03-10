using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SingleFire : CharacterCommand
{
    public SingleFire()
    {
        OnExecute = SingleFireExec;
        IsEnabled = SingleFireEnabled;

        SelfPositions = new List<int>() { 1, 2, 3 };
        EnemyPositions = new List<int>() { 1, 2, 3 };

        Name = "Single fire";

        damage = 15;

        Conditioning.SetBleeding(1f, 2, 3);
        Conditioning.SetPoisoning(1f, 2, 1);
        Conditioning.SetArsoning(1f, 4, 1);
    }

    private void SingleFireExec()
    {
        
    }

    private bool SingleFireEnabled(EntityBase entity)
    {
        return SelfPositions.Contains(entity.Position);
    }

    public override bool IsAvaliable(EntityBase entity)
    {
        if (entity is Character)
        {
            return (entity as Character).Weapon.Type == WeaponType.Pistol;
        }

        return true;
    }

    public override List<EntityBase> GetAvaliableTargets(int selfPosition, List<EntityBase> targetPositions)
    {
        if (selfPosition < 4)
        {
            return new List<EntityBase>();
        }

        return targetPositions.Where(x => x.Position < 9 && x.Position > 5 && !x.OnDeathDoor).ToList();
    }

    public override CommandResult Execute(EntityBase actor, List<EntityBase> targets)
    {
        var result = new CommandResult();
        var target = targets.FirstOrDefault();
        result.TargetStates.Add(target.Position, target.TakeDamage(damage, actor.EntityChars, Effect, Conditioning));
        result.Actor = actor;
        result.ActorPoseName = Poses.PistolFire;

        return result;
    }

    //public override List<int> GetSelectedTargets(int targetPosition)
    //{
    //    if (targetPosition == 6)
    //    {
    //        return new List<int>() { 6, 9 };
    //    }
    //    if (targetPosition == 8)
    //    {
    //        return new List<int>() { 8, 10 };
    //    }

    //    return new List<int>() { 7 };
    //}

    public override string IconName => "singlefirecommand_sprite";
    public override string EffectName => "singlefireeffect_sprite";
}

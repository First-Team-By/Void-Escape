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

    public override List<int> GetAvaliableTargets(int selfPosition, List<int> targetPositions)
    {
        if (selfPosition < 4)
        {
            return new List<int>();
        }

        return targetPositions.Where(x => x < 9 && x > 5).ToList();
    }

    public override CommandResult Execute(EntityBase actor, IEnumerable<EntityBase> targets)
    {
        return new CommandResult();
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
}

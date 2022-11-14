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
}

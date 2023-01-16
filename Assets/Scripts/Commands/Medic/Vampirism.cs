using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Vampirism : CharacterCommand
{
    public override string IconName { get; }
    public override string EffectName { get; }

    public Vampirism()
    {
        
    }
    public override CommandResult Execute(EntityBase actor, List<EntityBase> targets)
    {
        throw new NotImplementedException();
    }

    public override bool IsAvaliable(EntityBase entity)
    {
        throw new NotImplementedException();
    }

    private bool VampirismEnabled(EntityBase entity)
    {
        return SelfPositions.Contains(entity.Position);
    }
}

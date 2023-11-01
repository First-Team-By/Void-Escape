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
    public override CommandResult Execute(BattleCommandExecuteInfo executeInfo)
    {
        throw new NotImplementedException();
    }

    public override bool IsAvaliable(EntityInfo entity)
    {
        throw new NotImplementedException();
    }

    private bool VampirismEnabled(EntityInfo entity)
    {
        return SelfPositions.Contains(entity.Position);
    }
}

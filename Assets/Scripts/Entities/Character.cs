using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Character : EntityBase
{
    public EntityWeapon Weapon { set; get; }
    public EntityDevice Device { set; get; }
    public abstract List<CharacterCommand> NativeCommands { get; }

    public override List<EntityCommand> Commands
    {
        get
        {
            return NativeCommands.Where(x => x.IsAvaliable(this)).Select(x => x as EntityCommand).ToList();
        }
    }

    //public override List<EntityCommand> Commands()
    //{
    //    var result = new List<EntityCommand>();
    //    result.AddRange(Weapon.Commands);
    //    result.AddRange(Tool.Commands);

    //    return result;
    //}
}

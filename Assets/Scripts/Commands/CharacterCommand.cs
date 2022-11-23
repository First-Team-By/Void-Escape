using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class CharacterCommand : EntityCommand
{
    public abstract bool IsAvaliable(EntityBase entity);
}

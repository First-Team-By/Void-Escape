using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class CharacterCommand : EntityCommand
{
    protected float damage;
    public abstract bool IsAvaliable(EntityBase entity);
}

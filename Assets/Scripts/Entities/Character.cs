using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities
{
    public class Character : EntityBase
    {
        public EntityWeapon Weapon { set; get; }
        public EntityTool Tool { set; get; }
        public override List<EntityCommand> Commands()
        {
            var result = new List<EntityCommand>();
            result.AddRange(Weapon.Commands);
            result.AddRange(Tool.Commands);

            return result;
        }
    }
}

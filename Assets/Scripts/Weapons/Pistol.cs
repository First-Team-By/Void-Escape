using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Pistol : EntityWeapon
    {
        public override List<EntityCommand> Commands 
        {
            get
            {
                return new List<EntityCommand>
                {
                    new DoubleTap()
                };
            }
        }

    }
}
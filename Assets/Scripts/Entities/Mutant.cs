using Assets.Scripts.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Mutant : Enemy
    {
        public override List<EntityCommand> Commands()
        {
            return new List<EntityCommand>() { new ClawStrike() };
        }
    }
}
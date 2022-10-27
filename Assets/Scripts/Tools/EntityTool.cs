using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools
{
    public abstract class EntityTool : MonoBehaviour
    {
        public abstract List<EntityCommand> Commands { get; }
    }
}
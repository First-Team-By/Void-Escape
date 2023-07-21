using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.Networking.UnityWebRequest;

public class EntityMutilation
{
    public string Name { get; set; }
    public Resource CostToHeal { get; set; } = new Resource();
    
    public virtual EntityCharacteristics Affect(EntityCharacteristics characteristics)
    {
        return characteristics; 
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public enum CapsuleStatus
{
    UnFreezed,
    Opened,
    Empty,
    Freezed
}

public class HibernateCapsule
{
    private Character _character;

    public Character Character
    {
        get { return _character; }
        set { _character = value; }
    }

    public CapsuleStatus Status { get; set; }

    public HibernateCapsule()
    {
        Status = CapsuleStatus.UnFreezed;
    }
 
}


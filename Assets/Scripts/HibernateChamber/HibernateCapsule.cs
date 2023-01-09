using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public enum CapsuleStatus
{
    JustOpened,
    Opened,
    Empty,
    Rejected
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
        Status = CapsuleStatus.JustOpened;
    }
 
}


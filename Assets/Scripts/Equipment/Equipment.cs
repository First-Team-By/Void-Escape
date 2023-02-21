using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private SlotType _slotType;

    public SlotType SlotType => _slotType;
}

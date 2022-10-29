using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity Visuals", menuName = "Game/Entities/Entity Visuals")]
public class EntityVisuals : ScriptableObject
{
    [SerializeField] private Sprite entityIcon;
    [SerializeField] private Animator entityAnimator;

    public Sprite _entityIcon => entityIcon;
    public Animator _entityAnimator => entityAnimator;
}

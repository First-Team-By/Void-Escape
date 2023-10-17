using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefendingShot : CharacterCommand
{
	public override string IconName => "Engineer/defendingshot-icon_sprite";

	public override string EffectName => "effect_singlefire_sprite";

	public DefendingShot()
	{
		damage = 7;
		IsEnabled = DefendingShotEnabled;

		SelfPositions = new List<int>() { 1, 2, 3 };
		EnemyPositions = new List<int>() { 1, 2, 3 };

		Name = "<size=30><color=#ffa500ff>Оборонительный выстрел</color></size>";

		Description = "\n<color=#0000ffff>Наносит слабый урон любому противнику в первом ряду. Инженер перемещается во второй ряд, меняясь местами с товарищем за спиной, если он есть.</color>";

		FullDescription = Name + "\n" + Description;

		Conditioning.SetBleeding(1f, 2, 3);
		Conditioning.SetPoisoning(1f, 2, 1);
		Conditioning.SetBurning(1f, 4, 1);
	}
	
	private bool DefendingShotEnabled(EntityInfo entity)
	{
		return SelfPositions.Contains(entity.Position);
	}

	public override CommandResult Execute(EntityInfo actor, List<EntityInfo> targets)
	{
		var result = new CommandResult();
        foreach (var target in targets)
        {
            result.TargetStates.Add(target.Position, target.TakeDamage(damage, actor.EntityChars, Effect, Conditioning));
        }
        result.Actor = actor;
        //result.ActorPose = EntityPose.AttackPose;
        result.ActorPoseName = Poses.PistolFire;
        
        return result;
	}

	public override bool IsAvaliable(EntityInfo entity)
	{
		if (entity is CharacterInfo)
        {
            return (entity as CharacterInfo).Weapon != null && (entity as CharacterInfo).Weapon.Type == WeaponType.Pistol;
        }

        return true;
	}

    public override List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targetPositions)
    {
        if (selfPosition > 3)
        {
            return new List<EntityInfo>();
        }
        if (selfPosition == 1)
        {
            return targetPositions.Where(x => x.Position == 6 || x.Position == 7 && !x.OnDeathDoor).ToList();
        }
        if (selfPosition == 3)
        {
            return targetPositions.Where(x => x.Position == 7 || x.Position == 8 && !x.OnDeathDoor).ToList();
        }
        
        return targetPositions.Where(x => x.Position < 9 && x.Position > 5 && !x.OnDeathDoor).ToList();
    }
}

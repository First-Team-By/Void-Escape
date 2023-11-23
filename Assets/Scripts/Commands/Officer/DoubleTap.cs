using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleTap : CharacterCommand
{
	public DoubleTap()
	{
		damage = 10;

		SelfPositions = new List<int>() { 1, 2, 3 };

		Name = "<size=30><color=#ffa500ff>Двойной выстрел</color></size>";

		Description = "\n<color=#0000ffff>(Персонаж обязан находиться в первой линии.)</color>\nНаносит урон одной из двух ближайших целей.";

		FullDescription = Name + "\n" + Description;
	}

	public override bool IsAvaliable(EntityInfo entity)
	{
		if (entity is CharacterInfo)
		{
			return (entity as CharacterInfo).Weapon != null && (entity as CharacterInfo).Weapon.Type == WeaponType.Pistol;
		}

		return true;
	}

	public override string IconName => "Officer/command_doubletap_sprite";
	public override string EffectName => "effect_doubletap_sprite";

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

	public override CommandResult Execute(BattleCommandExecuteInfo executeInfo)
	{
		var result = base.Execute(executeInfo);
		foreach (var target in executeInfo.Targets)
		{
			var targetState = AttackResolver.ResolveAttack(damage, executeInfo.Actor, target, Conditioning);
			//target.TakeDamage(damage, executeInfo.Actor.EntityChars, Effect, Conditioning);
			result.TargetStates.Add(target.Position, targetState);
		}
		
		result.ActorPoseName = PosesConst.PistolFire;
		return result;
	}
}


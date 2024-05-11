using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DeepCut : CharacterCommand
{
	public override string IconName => "Medic/command_deepcut_sprite";
	public override string EffectName => "effect_slash_sprite";

	public DeepCut()
	{
		SelfPositions = new List<int>() { 1, 2, 3 };

		Name = "<size=30><color=#ffa500ff>Глубойкий порез</color></size>";

		Description = "\n<color=#0000ffff>(Умение доступно при условии что в руке\nперсонажа находится скальпель.\nПерсонаж обязан находиться в первой линии.)</color>" +
			"\nНаносит урон одной из двух ближайших целей\nтак же вешает на противника <color=#ff0000ff>Кровотечение.</color>";

		FullDescription = Name + "\n" + Description;

		damage = 10;

		Conditioning.SetBleeding(.5f, 3, 3);
	}
	public override CommandResult Execute(BattleCommandExecuteInfo executeInfo)
	{
		var result = base.Execute(executeInfo);
		foreach (var target in executeInfo.Targets)
		{
			var targetState = AttackResolver.ResolveAttack(damage, executeInfo.Actor, target, Conditioning);
			result.TargetStates.Add(target.Position, targetState);
		}
		
		result.ActorPoseName = PosesConst.BladeSlash;
		return result;
	}

	public override bool IsAvaliable(EntityInfo entity)
	{
		if (entity is CharacterInfo)
		{
			return (entity as CharacterInfo).Weapon?.Type == WeaponType.Scalpel;
		}

		return false;
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

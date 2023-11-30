using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackResolver
{
	public static TargetState ResolveAttack(float baseDamage, EntityInfo attacker, EntityInfo target, Conditioning conditioning)
	{
		var result = new TargetState();
		var attackerChars = attacker.EntityChars;
		var targetChars = target.EntityChars;
        result.Target = target;

        if (Random.Range(0, 1f) < Mathf.Clamp(targetChars.EvadeChance - attackerChars.Accuracy, 0, 1f))
		{
			result.PoseName = PosesConst.Evade;
            Debug.Log(target.ClassName + " уворачивается");
            return result;
		} 

		var finalDamage = baseDamage;
		if (Random.Range(0, 1f) < attackerChars.CritChance)
		{
			finalDamage *= attackerChars.CritMultiplier;
		}

		finalDamage -= finalDamage * target.Resistances.DamageResistance / 100;

		if (finalDamage > 0 && conditioning.CanGetBleed)
		{
			var chance = Random.Range(0, 1f);
			if (chance <= conditioning.Bleeding.Chance - conditioning.Bleeding.Chance * target.Resistances.BleedResistance / 100)
			{
				target.GetBleeded(conditioning.Bleeding.Damage, conditioning.Bleeding.Duration);
			}
		}

		if (finalDamage > 0 && conditioning.CanGetPoison)
		{
			var chance = Random.Range(0, 1f);
			if (chance <= conditioning.Poisoning.Chance - conditioning.Poisoning.Chance * target.Resistances.PoisonResistance / 100)
			{
				target.GetPoisoned(conditioning.Poisoning.Damage, conditioning.Poisoning.Duration);
			}
		}

		if (finalDamage > 0 && conditioning.CanGetArson)
		{
			var chance = Random.Range(0, 1f);
			if (chance <= conditioning.Burning.Chance - conditioning.Burning.Chance * target.Resistances.BurnResistance / 100)
			{
				target.GetBurn(conditioning.Burning.Damage, conditioning.Burning.Duration);
			}
		}

		target.Health -= finalDamage;
		result.HealthChanged = -finalDamage;
        result.PoseName = PosesConst.Suffering;
        Debug.Log(target.ClassName + " получает " + finalDamage + " урона");
        return result;
	}
}

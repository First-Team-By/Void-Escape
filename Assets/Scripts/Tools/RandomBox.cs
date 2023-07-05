using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.VR;

public static class RandomBox
{
    public static IRandomItem PickRandom(List<IRandomItem> list)
    {
        var sum = list.Sum(x => x.Frequency);
        var randomValue = new Random().Next(0, sum);

        var currentSum = 0;
        for (var i = 0; i < list.Count; i++)
        {
            currentSum += list[i].Frequency;
            if (currentSum >= randomValue)
            {
                return list[i];
            }
        }

        return null;
    }
}

public interface IRandomItem
{
    public int Frequency { get; set; }
}
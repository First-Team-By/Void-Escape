using System;
using System.Collections.Generic;
using System.Linq;

public static class RandomBox
{
    public static IRandomItem PickRandom(List<IRandomItem> list)
    {
        var sum = list.Sum(x => x.Weight);
        var randomValue = new Random().Next(0, sum);

        var currentSum = 0;
        for (var i = 0; i < list.Count; i++)
        {
            currentSum += list[i].Weight;
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
    public int Weight { get; set; }
}
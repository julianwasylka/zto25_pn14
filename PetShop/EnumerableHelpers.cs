using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableHelpers
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<Pet> AllPetsThatSatisfy(this IList<Pet> pets, Predicate<Pet> condition)
    {
        foreach (var pet in pets)
        {
            if (condition(pet))
            {
                yield return pet;
            }
        }
    }
}
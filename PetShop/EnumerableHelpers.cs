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
    public static IEnumerable<TItem> AllItemsThat<TItem>(this IList<TItem> items, Predicate<TItem> predicate)
    {
        return items.AllItemsThat(new AnonymousCriteria<TItem>(predicate));
    }

    public static IEnumerable<TItem> AllItemsThat<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
            {
                yield return item;
            }
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> _predicate;

    public AnonymousCriteria(Predicate<T> predicate)
    {
        _predicate = predicate;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _predicate(item);
    }
}

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DuplicatedKeyEnumerable<TKey, TValue> : IEnumerable<TValue>
{
    private readonly List<(TKey key, TValue value)> items;

    public DuplicatedKeyEnumerable()
    {
        items = new List<(TKey, TValue)>();
    }

    public void Add(TKey key, TValue value)
    {
        items.Add((key, value));
    }

    public bool ContainsKey(TKey key)
    {
        return items.Any(item => item.key.Equals(key));
    }

    public IEnumerable<TKey> Keys => items.Select(item => item.key).Distinct();

    public IEnumerable<TValue> Values => items.Select(item => item.value);

    public IEnumerable<TValue> this[TKey key] => items.Where(item => item.key.Equals(key)).Select(item => item.value);

    public IEnumerator<TValue> GetEnumerator()
    {
        return Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

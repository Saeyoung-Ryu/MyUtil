using System;
using System.Collections;
using System.Collections.Generic;

namespace MyUtil;

public class Roulette<TKey> : IEnumerable<KeyValuePair<TKey, double>>
{
    private List<TKey> keys;
    private List<double> values;

    private double totalValue;

    public Roulette()
    {
        keys = new List<TKey>();
        values = new List<double>();
    }

    public int Count => keys.Count;

    public void Add(TKey key, double value)
    {
        if (ContainsKey(key))
        {
            throw new ArgumentException("An element with the same key already exists in the dictionary.");
        }

        keys.Add(key);
        values.Add(value);

        totalValue += value;
    }

    public double this[TKey key]
    {
        get
        {
            int index = keys.IndexOf(key);
            if (index == -1)
                throw new KeyNotFoundException("The key does not exist in the dictionary.");

            return values[index];
        }
        set
        {
            int index = keys.IndexOf(key);
            if (index == -1)
                throw new KeyNotFoundException("The key does not exist in the dictionary.");

            values[index] = value;
        }
    }

    public bool ContainsKey(TKey key)
    {
        return keys.Contains(key);
    }
    
    public void Clear()
    {
        keys.Clear();
        values.Clear();
        totalValue = 0;
    }
    
    public void Remove(TKey key)
    {
        int index = keys.IndexOf(key);
        if (index == -1)
            return;

        totalValue -= values[index];

        keys.RemoveAt(index);
        values.RemoveAt(index);
    }
    
    public void RemoveAt(int index)
    {
        if (index >= keys.Count)
            return;

        totalValue -= values[index];

        keys.RemoveAt(index);
        values.RemoveAt(index);
    }

    public TKey StartRoulette()
    {
        // Generate a random number between 0 and the total sum
        double randomNumber = new Random().NextDouble() * totalValue;

        // Iterate over keys and subtract their corresponding probability until the random number is less than or equal to 0
        double cumulativeProbability = 0;
        for (int i = 0; i < keys.Count; i++)
        {
            cumulativeProbability += values[i];
            if (randomNumber <= cumulativeProbability)
            {
                return keys[i];
            }
        }

        // This should not happen unless there's a problem with the probabilities
        throw new InvalidOperationException("Failed to select a key.");
    }

    public IEnumerator<KeyValuePair<TKey, double>> GetEnumerator()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            yield return new KeyValuePair<TKey, double>(keys[i], values[i]);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
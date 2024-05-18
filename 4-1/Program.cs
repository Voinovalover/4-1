using System;
using System.Collections.Generic;
using System.Linq;

public class OneDimensionalArray<T> where T : IComparable<T>
{
    private List<T> array;

    public delegate bool ConditionDelegate(T item);
    public delegate void ActionDelegate(T item);
    public delegate TResult ProjectionDelegate<TResult>(T item);

    public OneDimensionalArray()
    {
        array = new List<T>(10);
    }

    public void Add(T item)
    {
        array.Add(item);
    }

    public void RemoveAt(int index)
    {
        array.RemoveAt(index);
    }

    public void Sort()
    {
        array.Sort();
    }

    public int Count()
    {
        return array.Count;
    }

    public int Count(ConditionDelegate condition)
    {
        int result = 0;
        foreach (var item in array)
        {
            if (condition(item))
                result++;
        }
        return result;
    }

    public bool Any(ConditionDelegate condition)
    {
        foreach (var item in array)
        {
            if (condition(item))
                return true;
        }
        return false;
    }

    public bool All(ConditionDelegate condition)
    {
        foreach (var item in array)
        {
            if (!condition(item))
                return false;
        }
        return true;
    }

    public bool Contains(T item)
    {
        return array.Contains(item);
    }

    public T FirstOrDefault(ConditionDelegate condition)
    {
        foreach (var item in array)
        {
            if (condition(item))
                return item;
        }
        return default(T);
    }

    public void ForEach(ActionDelegate action)
    {
        foreach (var item in array)
        {
            action(item);
        }
    }

    public List<T> Where(ConditionDelegate condition)
    {
        var result = new List<T>();
        foreach (var item in array)
        {
            if (condition(item))
                result.Add(item);
        }
        return result;
    }

    public List<TResult> Select<TResult>(ProjectionDelegate<TResult> projection)
    {
        var result = new List<TResult>();
        foreach (var item in array)
        {
            result.Add(projection(item));
        }
        return result;
    }

    public T Min()
    {
        return array.Min();
    }

    public T Max()
    {
        return array.Max();
    }
}

class Program
{
    static void Main()
    {
        var intArray = new OneDimensionalArray<int>();

        intArray.Add(3);
        intArray.Add(1);
        intArray.Add(2);

        intArray.Sort();

        Console.WriteLine("Sorted Array:");
        intArray.ForEach(item => Console.WriteLine(item));

        Console.WriteLine("Min Value: " + intArray.Min());
        Console.WriteLine("Max Value: " + intArray.Max());
    }
}
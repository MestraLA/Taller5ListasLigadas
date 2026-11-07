
using Taller5ListasLigadas.Backend.DataStructures;

namespace Taller5ListasLigadas.Backend.Services;

public static class StatisticsService
{
    public static Dictionary<T, int> GetFrequencies<T>(
        DoublyLinkedList<T> list) where T : notnull
    {
        Dictionary<T, int> frequencies = new Dictionary<T, int>();

        foreach (T item in list.GetForward())
        {
            if (frequencies.ContainsKey(item))
            {
                frequencies[item]++;
            }
            else
            {
                frequencies.Add(item, 1);
            }
        }

        return frequencies;
    }

    public static List<T> GetModes<T>(
        DoublyLinkedList<T> list) where T : notnull
    {
        Dictionary<T, int> frequencies = GetFrequencies(list);

        List<T> modes = new List<T>();

        if (frequencies.Count == 0)
        {
            return modes;
        }

        int maxFrequency = frequencies.Values.Max();

        foreach (KeyValuePair<T, int> item in frequencies)
        {
            if (item.Value == maxFrequency)
            {
                modes.Add(item.Key);
            }
        }

        return modes;
    }
}

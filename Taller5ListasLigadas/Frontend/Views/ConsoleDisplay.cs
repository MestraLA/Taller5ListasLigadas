namespace Taller5ListasLigadas.Frontend.Views;

public static class ConsoleDisplay
{
    public static void ShowValues<T>(
        IEnumerable<T> values,
        string title)
    {
        Console.WriteLine($"\n{title}");
        Console.WriteLine("--------------------------------");

        bool hasElements = false;

        foreach (T item in values)
        {
            Console.Write(item + " ");
            hasElements = true;
        }

        if (!hasElements)
        {
            Console.WriteLine("La lista esta vacia.");
        }
        else
        {
            Console.WriteLine();
        }
    }

    public static void ShowModes<T>(IEnumerable<T> modes)
    {
        Console.WriteLine("\nMODA(S)");
        Console.WriteLine("--------------------------------");

        List<T> result = modes.ToList();

        if (result.Count == 0)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        if (result.Count == 1)
        {
            Console.WriteLine($"La moda es: {result[0]}");
        }
        else
        {
            Console.Write("Las modas son: ");

            foreach (T mode in result)
            {
                Console.Write(mode + " ");
            }

            Console.WriteLine();
        }
    }

    public static void ShowFrequencyGraph<T>(
        Dictionary<T, int> frequencies) where T : notnull
    {
        Console.WriteLine("\nGRAFICO DE OCURRENCIAS");
        Console.WriteLine("--------------------------------");

        if (frequencies.Count == 0)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        foreach (KeyValuePair<T, int> item in frequencies)
        {
            string graph = new string('*', item.Value);

            Console.WriteLine($"{item.Key} {graph}");
        }
    }
}

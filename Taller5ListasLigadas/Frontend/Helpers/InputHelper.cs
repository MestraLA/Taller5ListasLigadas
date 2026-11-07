
namespace Taller5ListasLigadas.Frontend.Helpers;

public static class InputHelper
{
    public static int GetInt(string message)
    {
        int number;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }

            Console.WriteLine("Error: ingrese un numero entero valido.");
        }
    }

    public static int GetMenuOption()
    {
        return GetInt("Seleccione una opcion: ");
    }

    public static void Pause()
    {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }
}

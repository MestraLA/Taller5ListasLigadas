
using Taller5ListasLigadas.Backend.DataStructures;
using Taller5ListasLigadas.Backend.Services;
using Taller5ListasLigadas.Frontend.Helpers;
using Taller5ListasLigadas.Frontend.Views;

namespace Taller5ListasLigadas.Frontend.Menus;

public class Menu
{
    private readonly DoublyLinkedList<int> _numbers;

    public Menu()
    {
        _numbers = new DoublyLinkedList<int>();
    }

    public void Run()
    {
        int option;

        do
        {
            ShowMenu();

            option = InputHelper.GetMenuOption();

            Console.Clear();

            switch (option)
            {
                case 1:
                    Add();
                    break;

                case 2:
                    ShowForward();
                    break;

                case 3:
                    ShowBackward();
                    break;

                case 4:
                    SortDescending();
                    break;

                case 5:
                    ShowModes();
                    break;

                case 6:
                    ShowGraph();
                    break;

                case 7:
                    Search();
                    break;

                case 8:
                    RemoveOne();
                    break;

                case 9:
                    RemoveAll();
                    break;

                case 0:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

            if (option != 0)
            {
                InputHelper.Pause();
                Console.Clear();
            }

        } while (option != 0);
    }

    private void ShowMenu()
    {
        Console.WriteLine("====================================");
        Console.WriteLine("       TALLER 5 - LISTAS LIGADAS");
        Console.WriteLine("====================================");
        Console.WriteLine();
        Console.WriteLine("1. Adicionar");
        Console.WriteLine("2. Mostrar hacia adelante");
        Console.WriteLine("3. Mostrar hacia atras");
        Console.WriteLine("4. Ordenar descendentemente");
        Console.WriteLine("5. Mostrar la(s) moda(s)");
        Console.WriteLine("6. Mostrar grafico");
        Console.WriteLine("7. Existe");
        Console.WriteLine("8. Eliminar una ocurrencia");
        Console.WriteLine("9. Eliminar todas las ocurrencias");
        Console.WriteLine("0. Salir");
        Console.WriteLine();
    }

    private void Add()
    {
        int number = InputHelper.GetInt("Ingrese el numero: ");

        // Garantizar que la lista este ascendente
        // antes de realizar una nueva insercion.
        _numbers.SortAscending();

        _numbers.AddSorted(number);

        Console.WriteLine("\nElemento agregado correctamente.");
    }

    private void ShowForward()
    {
        ConsoleDisplay.ShowValues(
            _numbers.GetForward(),
            "LISTA HACIA ADELANTE");
    }

    private void ShowBackward()
    {
        ConsoleDisplay.ShowValues(
            _numbers.GetBackward(),
            "LISTA HACIA ATRAS");
    }

    private void SortDescending()
    {
        _numbers.SortDescending();

        Console.WriteLine("Lista ordenada descendentemente.");
    }

    private void ShowModes()
    {
        var modes = StatisticsService.GetModes(_numbers);

        ConsoleDisplay.ShowModes(modes);
    }

    private void ShowGraph()
    {
        var frequencies =
            StatisticsService.GetFrequencies(_numbers);

        ConsoleDisplay.ShowFrequencyGraph(frequencies);
    }

    private void Search()
    {
        int number = InputHelper.GetInt("Numero a buscar: ");

        if (_numbers.Contains(number))
        {
            Console.WriteLine($"El numero {number} SI existe.");
        }
        else
        {
            Console.WriteLine($"El numero {number} NO existe.");
        }
    }

    private void RemoveOne()
    {
        int number = InputHelper.GetInt(
            "Numero que desea eliminar: ");

        if (_numbers.RemoveOne(number))
        {
            Console.WriteLine("Una ocurrencia eliminada correctamente.");
        }
        else
        {
            Console.WriteLine("El elemento no existe.");
        }
    }

    private void RemoveAll()
    {
        int number = InputHelper.GetInt(
            "Numero que desea eliminar: ");

        int removed = _numbers.RemoveAll(number);

        Console.WriteLine($"Total de ocurrencias eliminadas: {removed}");
    }
}

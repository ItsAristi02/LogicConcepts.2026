do
{
    Console.Write("Ingrese un número o escriba 'salir' : ");
    string texto = Console.ReadLine();

    if (texto == "salir")
    {
        Console.WriteLine("Saliendo del programa...");
        break;
    }

    int numero;

    if (int.TryParse(texto, out numero))
    {
        

        if (numero % 2 == 0)
        {
            Console.WriteLine($"El número {numero}, es par.");
        }
        else
        {
            Console.WriteLine($"El número {numero}, es impar.");
        }
    }
    else
    {
        Console.WriteLine("El dato ingresado no es un número.");
    }

    Console.WriteLine();

} while (true);


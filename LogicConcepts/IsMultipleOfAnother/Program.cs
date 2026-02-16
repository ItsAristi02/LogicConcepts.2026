using Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

do
{
    Console.WriteLine("Ingrese dos numeros o escriba 'salir'.");

    string? texto = Console.ReadLine();

    if (texto.Trim().ToLower() == "salir")
    {
        Console.WriteLine("Saliendo del programa...");
        break;
    }

    int num1 = ConsoleExtension.GetInt("Primer numero: ");
    int num2 = ConsoleExtension.GetInt("Segundo numero: ");

    if (num1 == 0)
    {
        Console.WriteLine("El primer numero no puede ser cero.");
    }
    else
    {
        if (num2 % num1 == 0)
        {
            Console.WriteLine($"El {num2} ES multiplo del primero.");
        }
        else
        {
            Console.WriteLine($"El {num2} NO es multiplo del primero.");
        }
    }

    Console.WriteLine();

}
while (true);


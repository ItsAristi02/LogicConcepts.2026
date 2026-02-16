using Shared;


string opcion = string.Empty;
List<string> opciones = new List<string> { "si", "no" };

do
{
    Console.WriteLine("Ingrese 3 números para saber cuál es el mayor.");

    int num1 = ConsoleExtension.GetInt("Primer número: ");
    int num2 = ConsoleExtension.GetInt("Segundo número: ");
    int num3 = ConsoleExtension.GetInt("Tercer número: ");

    int mayor = num1;

    if (num2 > mayor)
    {
        mayor = num2;
    }

    if (num3 > mayor)
    {
        mayor = num3;
    }

    Console.WriteLine($"El número mayor es: {mayor}");

    opcion = ConsoleExtension.GetValidOptions("¿Desea ingresar otros números? (si/no): ", opciones) ?? string.Empty;

    Console.WriteLine();


}
while (opcion != "no");

Console.WriteLine("¡Gracias por usar el programa!");
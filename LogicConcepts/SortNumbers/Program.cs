using Shared;


string opcion = string.Empty;
List<string> opciones = new List<string> { "si", "no" };

do
{

    Console.WriteLine("Ingrese 3 números diferentes.");

    int num1 = ConsoleExtension.GetInt("Primer número: ");
    int num2 = ConsoleExtension.GetInt("Segundo número: ");
    int num3 = ConsoleExtension.GetInt("Tercer número: ");

    if (num1 == 0 || num2 == 0 || num3 == 0)
    {
        Console.WriteLine("Debe ingresar números validos.");
    }
    else if (num1 == num2 || num1 == num3 || num2 == num3)
    {
        Console.WriteLine("Los números no pueden ser iguales.");
    }
    else
    {
        int mayor = num1;
        int menor = num1;

        if (num2 > mayor) mayor = num2;
        if (num3 > mayor) mayor = num3;

        if (num2 < menor) menor = num2;
        if (num3 < menor) menor = num3;

        int medio = num1 + num2 + num3 - mayor - menor;

        Console.WriteLine($"El número mayor es {mayor}, el del medio es {medio}, el menor es {menor}");
    }

    opcion = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", opciones);

    Console.WriteLine();


}
while (opcion != "no");

Console.WriteLine("¡Gracias por usar el programa!");
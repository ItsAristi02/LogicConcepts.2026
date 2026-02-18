using Shared;

string opcion = string.Empty;
List<string> opciones = new List<string> { "si", "no" };

do
{
    Console.WriteLine("Ingrese un año.");
    int year = ConsoleExtension.GetInt("Año: ");
    int currentYear = DateTime.Now.Year;


    bool esBisiesto;

    if (year % 4 == 0 && year % 100 != 0)
        esBisiesto = true;
    else if (year % 100 == 0 && year % 400 == 0)
        esBisiesto = true;
    else
        esBisiesto = false;

    string complemento = year < currentYear ? "fue" : year == currentYear ? "es" : "será";
    string resultado = esBisiesto ? "sí" : "no";

    Console.WriteLine($"El año {year} {resultado} {complemento} bisiesto.");

    opcion = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", opciones);

    Console.WriteLine();

} while (opcion != "no");

Console.WriteLine("¡Gracias por usar el programa!");
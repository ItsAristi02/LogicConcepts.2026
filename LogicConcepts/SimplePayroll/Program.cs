using Shared;

string answer = string.Empty;
List<string> options = new List<string> { "si", "no" };

do
{
    string name = ConsoleExtension.GetString("Ingrese el nombre del empleado: ");
    decimal hourlyRate = ConsoleExtension.GetDecimal("Ingrese el valor por hora: ");
    int hoursWorked = ConsoleExtension.GetInt("Ingrese las horas trabajadas en el mes: ");
    decimal minimumWage = ConsoleExtension.GetDecimal("Ingrese el valor del salario minimo mensual: ");

    decimal monthlyWage = hourlyRate * hoursWorked;

    if (monthlyWage > minimumWage)
        Console.WriteLine($"Empleado: {name} - Salario mensual: {monthlyWage:C2}");
    else
        Console.WriteLine($"Empleado: {name} - Salario mensual: {minimumWage:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options) ?? string.Empty;

        if (string.IsNullOrEmpty(answer))
            Console.WriteLine("Opción no válida, por favor ingrese 'si' o 'no'.");
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("¡Gracias por usar el programa!");
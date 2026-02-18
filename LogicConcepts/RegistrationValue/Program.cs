using Shared;
string answer = string.Empty;
List<string> options = new List<string> { "si", "no" };


do
{
    int credits = ConsoleExtension.GetInt("Ingrese la cantidad de créditos: ");
    decimal creditValue = ConsoleExtension.GetDecimal("Ingrese el valor del crédito: ");
    int stratum = ConsoleExtension.GetInt("Ingrese el estrato (1-6): ");

    decimal enrollment = CalculateEnrollment(credits, creditValue, stratum);
    decimal subsidy = CalculateSubsidy(stratum);

    Console.WriteLine($"Valor de la matrícula: {enrollment,20:C2}");

    if (subsidy > 0)
        Console.WriteLine($"Subsidio de alimentación y transporte: {subsidy,20:C2}");
    else
        Console.WriteLine("No aplica subsidio de alimentación y transporte.");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options) ?? string.Empty;
        if (string.IsNullOrEmpty(answer))
            Console.WriteLine("Opción no válida, por favor ingrese 'si' o 'no'.");
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

    Console.WriteLine();

} while (answer!.Equals("si", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("¡Gracias por usar el programa!");

decimal CalculateEnrollment(int credits, decimal creditValue, int stratum)
{
    decimal total;
    if (credits <= 20)
    {
        total = credits * creditValue;
    }
    else
    {
        decimal extraCredits = credits - 20;
        total = (20 * creditValue) + (extraCredits * creditValue * 2);
    }

    if (stratum == 1)
        total = total - (total * 0.80m);
    else if (stratum == 2)
        total = total - (total * 0.50m);
    else if (stratum == 3)
        total = total - (total * 0.30m);

    return total;
}

decimal CalculateSubsidy(int stratum)
{
    decimal subsidy = 0;
    if (stratum == 1)
        subsidy = 200000m;
    else if (stratum == 2)
        subsidy = 100000m;
    return subsidy;
}
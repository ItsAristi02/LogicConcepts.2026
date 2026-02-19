using Shared;
using System.Runtime.Intrinsics.Arm;


string answer = string.Empty;

List<string> options = new List<string> { "si", "no" };
List<string> productTypeOptions = new List<string> { "p", "n" };
List<string> conservationTypeOptions = new List<string> { "frio", "ambiente" };
List<string> storageOptions = new List<string> { "nevera", "congelador", "estanteria", "guacal" };

do
{
    decimal cc = ConsoleExtension.GetDecimal("Ingrese el costo de compra: ");
    string tp = ConsoleExtension.GetValidOptions("Tipo de producto [P]erecedero, [N]o perecedero: ", productTypeOptions);
    while (string.IsNullOrEmpty(tp))
    {
        Console.WriteLine("Opción no válida, ingrese 'p' o 'n'.");
        tp = ConsoleExtension.GetValidOptions("Tipo de producto [P]erecedero, [N]o perecedero: ", productTypeOptions);
    }

    string tc = ConsoleExtension.GetValidOptions("Tipo de conservación (frio/ambiente): ", conservationTypeOptions);
    while (string.IsNullOrEmpty(tc))
    {
        Console.WriteLine("Opción no válida, ingrese 'frio' o 'ambiente'.");
        tc = ConsoleExtension.GetValidOptions("Tipo de conservación (frio/ambiente): ", conservationTypeOptions);
    }

    int pc = ConsoleExtension.GetInt("Periodo de conservación en días: ");
    int pa = ConsoleExtension.GetInt("Periodo de almacenamiento en días: ");
    decimal vol = ConsoleExtension.GetDecimal("Volumen en litros: ");

    string ma = ConsoleExtension.GetValidOptions("Medio de almacenamiento (nevera/congelador/estanteria/guacal): ", storageOptions);
    while (string.IsNullOrEmpty(ma))
    {
        Console.WriteLine("Opción no válida, ingrese 'nevera', 'congelador', 'estanteria' o 'guacal'.");
        ma = ConsoleExtension.GetValidOptions("Medio de almacenamiento (nevera/congelador/estanteria/guacal): ", storageOptions);
    }

    decimal ca = CalculateStorageCost(cc, tp, tc, pc, pa, vol);
    decimal ce = CalculateExhibitionCost(ca, tp, tc, ma);
    decimal pdp = CalculateDepreciation(pa);
    decimal vrP = GetProductValue(cc, ca, ce, pdp);
    decimal vrV = GetSaleValue(vrP, tp);

    Console.WriteLine($"Costo de almacenamiento:  {ca,20:C2}");
    Console.WriteLine($"Porcentaje depreciación:  {pdp,20:P2}");
    Console.WriteLine($"Costo de exhibición:      {ce,20:C2}");
    Console.WriteLine($"Valor del producto VR_P:  {vrP,20:C2}");
    Console.WriteLine($"Valor de venta VR_V:      {vrV,20:C2}");

    answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options);
    while (string.IsNullOrEmpty(answer))
    {
        Console.WriteLine("Opción no válida, ingrese 'si' o 'no'.");
        answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options);
    }

    Console.WriteLine();
} while (answer == "si");

Console.WriteLine("¡Gracias por usar el programa!");

decimal CalculateStorageCost(decimal cc, string tp, string tc, int pc, int pa, decimal vol)
{
    decimal ca = 0;
    if (tp == "p")
    {
        if (tc == "frio")
        {
            if (pc < 10)
                ca = cc * 0.05m;
            else
                ca = cc * 0.10m;
        }
        else if (tc == "ambiente")
        {
            if (pa < 20)
                ca = cc * 0.03m;
            else if (pa == 20)
                ca = cc * 0.05m;
            else
                ca = cc * 0.10m;
        }
    }
    else
    {
        if (vol >= 50)
            ca = cc * 0.10m;
        else
            ca = cc * 0.20m;
    }
    return ca;
}

decimal CalculateDepreciation(int pa)
{
    decimal pdp = 0;

    if (pa < 30)
        pdp = 0.95m;
    else
        pdp = 0.85m;
    return pdp;
}

decimal CalculateExhibitionCost(decimal ca, string tp, string tc, string ma)
{
    decimal ce = 0;
    if (tp == "p")
    {
        if (tc == "frio" && ma == "nevera")
            ce = ca * 2;
        else if (tc == "frio" && ma == "congelador")
            ce = ca;
    }
    else
    {
        if (ma == "estanteria")
            ce = ca * 0.05m;
        else if (ma == "guacal")
            ce = ca * 0.07m;
    }
    return ce;
}

decimal GetProductValue(decimal cc, decimal ca, decimal ce, decimal pdp)
{
    return (cc + ca + ce) * pdp;
}

decimal GetSaleValue(decimal vr_p, string? tp)
{
    if (tp!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        return vr_p * 1.4m;
    }
    return vr_p * 1.2m;
}
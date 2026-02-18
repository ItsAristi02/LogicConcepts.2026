using Shared;

string answer = string.Empty;
List<string> options = new List<string> { "si", "no" };

decimal deskPrice = 650000;

do
{
    int quantity = ConsoleExtension.GetInt("Ingrese la cantidad de escritorios: ");

    decimal discount;
    if (quantity < 5)
        discount = 0.10m;
    else if (quantity >= 5 && quantity < 10)
        discount = 0.20m;
    else
        discount = 0.40m;

    decimal subtotal = deskPrice * quantity;
    decimal discountAmount = subtotal * discount;
    decimal total = subtotal - discountAmount;

    Console.WriteLine($"Cantidad de escritorios: {quantity}");
    Console.WriteLine($"Subtotal: {subtotal:C2}");
    Console.WriteLine($"Descuento ({discount * 100}%): {discountAmount:C2}");
    Console.WriteLine($"Total a pagar: {total:C2}");

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
using Shared;


string answer = string.Empty;
List<string> options = new List<string> { "si", "no" };
List<string> paymentOptions = new List<string> { "efectivo", "tarjeta" };

do
{
    decimal weight = ConsoleExtension.GetDecimal("Ingrese el peso de la mercancía (kg): ");
    decimal merchandiseValue = ConsoleExtension.GetDecimal("Ingrese el valor de la mercancía: ");

    string promotionDay = ConsoleExtension.GetValidOptions("¿Es lunes? (si/no): ", options);
    while (string.IsNullOrEmpty(promotionDay))
    {
        Console.WriteLine("Opción no válida, ingrese 'si' o 'no'.");
        promotionDay = ConsoleExtension.GetValidOptions("¿Es lunes? (si/no): ", options);
    }

    string paymentMethod = ConsoleExtension.GetValidOptions("Método de pago (efectivo/tarjeta): ", paymentOptions);
    while (string.IsNullOrEmpty(paymentMethod))
    {
        Console.WriteLine("Opción no válida, ingrese 'efectivo' o 'tarjeta'.");
        paymentMethod = ConsoleExtension.GetValidOptions("Método de pago (efectivo/tarjeta): ", paymentOptions);
    }

    bool isMonday = promotionDay == "si";
    decimal shippingCost = CalculateRate(weight);
    decimal discount = CalculateDiscount(merchandiseValue, shippingCost);

    decimal promotion = 0;

    if (discount == 0)
    {
        promotion = CalculatePromotion(shippingCost, isMonday, paymentMethod, merchandiseValue);
    }

    decimal total = shippingCost - discount - promotion;

    Console.WriteLine($"Tarifa base:   {shippingCost,20:C2}");
    Console.WriteLine($"Descuento:     {discount,20:C2}");
    Console.WriteLine($"Promoción:     {promotion,20:C2}");
    Console.WriteLine($"Total a pagar: {total,20:C2}");

    answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options);
    while (string.IsNullOrEmpty(answer))
    {
        Console.WriteLine("Opción no válida, ingrese 'si' o 'no'.");
        answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options);
    }

    Console.WriteLine();
} while (answer == "si");

Console.WriteLine("¡Gracias por usar el programa!");

decimal CalculateRate(decimal weight)
{
    if (weight < 100)
    {
        return 20000;
    }
    else if (weight >= 100 && weight <= 150)
    {
        return 25000;
    }
    else if (weight > 150 && weight <= 200)
    {
        return 30000;
    }
    else
    {
        int additional = ((int)weight - 200) / 10;
        return 35000 + (additional * 2000);
    }
}

decimal CalculateDiscount(decimal merchandiseValue, decimal shippingCost)
{
    decimal discount = 0;
    if (merchandiseValue >= 300000 && merchandiseValue <= 600000)
        discount = shippingCost * 0.10m;
    else if (merchandiseValue > 600000 && merchandiseValue <= 1000000)
        discount = shippingCost * 0.20m;
    else if (merchandiseValue > 1000000)
        discount = shippingCost * 0.30m;
    return discount;
}

decimal CalculatePromotion(decimal shippingCost, bool isMonday, string paymentMethod, decimal merchandiseValue)
{
    decimal promotion = 0;
    if (isMonday && paymentMethod == "tarjeta")
        promotion = shippingCost * 0.50m;
    else if (paymentMethod == "efectivo" && merchandiseValue > 1000000)
        promotion = shippingCost * 0.40m;
    return promotion;
}
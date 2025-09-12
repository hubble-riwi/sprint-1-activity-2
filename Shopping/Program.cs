// Carrito de compras
List<Product> cart = new();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("----------- Bienvenido al sistema de carrito de compras -----------");
Console.ResetColor();

while (true)
{
    ShowMenu();
    Console.Write("--> ");
    string option = Console.ReadLine();

    bool exitFlag = false;

    switch (option)
    {
        case "1":
            AddProduct();
            break;

        case "2":
            ShowCart();
            break;

        case "3":
            CalculateTotal();
            break;

        case "4":
            ModifyProduct();
            break;

        case "5":
            RemoveProduct();
            break;

        case "6":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("¡Gracias por su compra!");
            Console.ResetColor();
            exitFlag = true;
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Debe ingresar una opción válida.");
            Console.ResetColor();
            break;
    }

    if (exitFlag)
        break;

    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}

void ShowMenu()
{
    Console.WriteLine(@"
===== Menú Carrito de Compras =====
1. Agregar Producto
2. Mostrar Carrito
3. Calcular Total
4. Modificar Producto
5. Eliminar Producto
6. Salir
=================================
Elija una opción:");
}

void AddProduct()
{
    Console.WriteLine("Ingrese el nombre del producto:");
    Console.Write("--> ");
    string name = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("El nombre del producto no puede estar vacío.");
        Console.ResetColor();
        return;
    }

    Console.WriteLine("Ingrese la cantidad:");
    Console.Write("--> ");
    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Debe ingresar una cantidad válida (número entero no negativo).");
        Console.ResetColor();
        return;
    }

    Console.WriteLine("Ingrese el precio unitario:");
    Console.Write("--> ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Debe ingresar un precio válido (número decimal no negativo).");
        Console.ResetColor();
        return;
    }

    Product product = new Product(name, quantity, price);
    cart.Add(product);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Producto agregado al carrito.");
    Console.ResetColor();
}

void ShowCart()
{
    Console.WriteLine("===== Detalle del Carrito =====");

    if (cart.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("El carrito está vacío.");
        Console.ResetColor();
        return;
    }

    foreach (var product in cart)
    {
        Console.WriteLine($"Producto: {product.Name}, Cantidad: {product.Quantity}, Precio: {product.Price:C}, Total: {product.Total():C}");
        if (product.Quantity == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("¡Advertencia! El producto tiene cantidad 0.");
            Console.ResetColor();
        }
    }
}

void CalculateTotal()
{
    decimal total = 0;
    foreach (var product in cart)
    {
        total += product.Total();
    }

    if (total > 200)
    {
        decimal discount = total * 0.1M;
        decimal discountedTotal = total - discount;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Se ha aplicado un descuento del 10%.");
        Console.WriteLine($"Total con descuento: {discountedTotal:C}");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine($"Total sin descuento: {total:C}");
    }
}

void ModifyProduct()
{
    Console.WriteLine("Ingrese el nombre del producto a modificar:");
    Console.Write("--> ");
    string name = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Debe ingresar un nombre válido.");
        Console.ResetColor();
        return;
    }

    Product product = cart.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (product != null)
    {
        Console.WriteLine($"Producto encontrado: {product.Name}, Cantidad actual: {product.Quantity}, Precio actual: {product.Price:C}");

        Console.WriteLine("Ingrese nueva cantidad:");
        Console.Write("--> ");
        if (!int.TryParse(Console.ReadLine(), out int newQuantity) || newQuantity < 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Debe ingresar una cantidad válida (número entero no negativo).");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Ingrese nuevo precio:");
        Console.Write("--> ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal newPrice) || newPrice < 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Debe ingresar un precio válido (número decimal no negativo).");
            Console.ResetColor();
            return;
        }

        product.Quantity = newQuantity;
        product.Price = newPrice;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Producto modificado.");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Producto no encontrado.");
        Console.ResetColor();
    }
}

void RemoveProduct()
{
    Console.WriteLine("Ingrese el nombre del producto a eliminar:");
    Console.Write("--> ");
    string name = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Debe ingresar un nombre válido.");
        Console.ResetColor();
        return;
    }

    Product product = cart.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (product != null)
    {
        cart.Remove(product);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Producto eliminado del carrito.");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Producto no encontrado.");
        Console.ResetColor();
    }
}

class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Product(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public decimal Total()
    {
        return Quantity * Price;
    }
}

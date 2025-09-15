List<Product> cart = new();
bool program = true;

while (program)
{
    Console.WriteLine("\n===== MENU CARRITO DE COMPRAS =====");
    Console.WriteLine("1) Agregar producto");
    Console.WriteLine("2) Mostrar carrito");
    Console.WriteLine("3) Revisar cantidades en cero");
    Console.WriteLine("4) Calcular total con descuento");
    Console.WriteLine("5) Editar producto");
    Console.WriteLine("6) Eliminar producto");
    Console.WriteLine("7) Salir");
    Console.Write(">>> ");

    string option = Console.ReadLine() ?? "";

    switch (option)
    {
        case "1": // Add product
            while (true)
            {
                Console.Write("\nNombre del producto: ");
                string name = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Nombre inválido.");
                    continue;
                }

                Console.Write("Cantidad: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                {
                    Console.WriteLine("Cantidad inválida.");
                    continue;
                }

                Console.Write("Precio: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
                {
                    Console.WriteLine("Precio inválido.");
                    continue;
                }

                cart.Add(new Product { Name = name, Quantity = quantity, Price = price });

                Console.Write("\n¿Quieres agregar otro producto? (s/n): ");
                string keep = (Console.ReadLine() ?? "").ToLower();
                if (keep == "n") break;
            }
            break;

        case "2": // Show cart
            if (cart.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                Console.WriteLine("\n===== DETALLE DEL CARRITO =====");
                for (int i = 0; i < cart.Count; i++)
                {
                    var p = cart[i];
                    Console.WriteLine($"{i}) Producto: {p.Name}, Cantidad: {p.Quantity}, Precio: {p.Price}");
                }
            }
            break;

        case "3": // Review 0 quantity
            foreach (var p in cart)
            {
                if (p.Quantity == 0)
                {
                    Console.WriteLine($"⚠ El producto {p.Name} tiene cantidad 0.");
                }
            }
            break;

        case "4": // Calculate total
            decimal total = 0;
            foreach (var p in cart)
            {
                total += p.Price * p.Quantity;
            }

            if (total > 200)
            {
                decimal discount = total * 0.10m;
                total -= discount;
                Console.WriteLine($"\nSe aplicó un 10% de descuento. Total final: {total}");
            }
            else
            {
                Console.WriteLine($"\nEl total de la compra es: {total}");
            }
            break;

        case "5": // Edit product
            if (cart.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                break;
            }

            Console.WriteLine("\nProductos en el carrito:");
            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine($"{i}) {cart[i].Name} (Cant: {cart[i].Quantity}, Precio: {cart[i].Price})");
            }

            Console.Write("Ingresa el número del producto a editar: ");
            if (!int.TryParse(Console.ReadLine(), out int editIndex) || editIndex < 0 || editIndex >= cart.Count)
            {
                Console.WriteLine("Índice inválido.");
                break;
            }

            Product selected = cart[editIndex];

            Console.WriteLine("\n¿Qué quieres editar?");
            Console.WriteLine("1) Nombre");
            Console.WriteLine("2) Cantidad");
            Console.WriteLine("3) Precio");
            Console.Write(">>> ");
            string editOption = Console.ReadLine() ?? "";

            switch (editOption)
            {
                case "1":
                    Console.Write("Nuevo nombre: ");
                    string newName = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newName)) selected.Name = newName;
                    break;
                case "2":
                    Console.Write("Nueva cantidad: ");
                    if (int.TryParse(Console.ReadLine(), out int newQty) && newQty >= 0)
                        selected.Quantity = newQty;
                    break;
                case "3":
                    Console.Write("Nuevo precio: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newPrice) && newPrice >= 0)
                        selected.Price = newPrice;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
            break;

        case "6": // Delete product
            if (cart.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                break;
            }

            Console.WriteLine("\nProductos en el carrito:");
            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine($"{i}) {cart[i].Name} (Cant: {cart[i].Quantity}, Precio: {cart[i].Price})");
            }

            Console.Write("Ingresa el número del producto a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int deleteIndex) || deleteIndex < 0 || deleteIndex >= cart.Count)
            {
                Console.WriteLine("Índice inválido.");
                break;
            }

            cart.RemoveAt(deleteIndex);
            Console.WriteLine("Producto eliminado.");
            break;

        case "7":
            program = false;
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

class Product
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

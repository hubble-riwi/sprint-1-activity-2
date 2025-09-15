List<Product> products = new(); 
List<Product>  shoppings = new();
double totalPrice = 0;
bool changeRol = true;
while (changeRol)
{
    
    

Console.WriteLine("Ingrese que rol deseas interpretar \n 1. admin (Crea, edita, elimina productos que el usuario puede agregar al carrito \n 2. Usuario (llena y administra su carrito de compras))");
int rolOption = int.Parse(Console.ReadLine());

switch (rolOption)
{
    case 1: 
        Crud_admin();
        break;
    case 2:
        shopee_user();
        break;
    
}
}


void shopee_user()
{
    bool returnMenuUser =  true;
    while (returnMenuUser) {
    Console.WriteLine("Hola bienvenido a mi tienda, que desea hacer? \n 1. Agregar productos al carrito \n 2. Crear factura ");
    int optionUserShop = int.Parse(Console.ReadLine());
    switch (optionUserShop)
    {
        case 1:
            Console.WriteLine("Estos son los productos de nuestra tienda: ");
            Console.WriteLine("--------------------------------------------");

            foreach (Product p in products)
            {
                Console.WriteLine($"Nombre: {p.name} \n Precio: {p.price} \n Cantidad: {p.amount}");
                Console.WriteLine("----------------------------------------------------");
                
            }

            bool outAddProductsCarShopee = true;
            while (outAddProductsCarShopee)
            {
                
            Console.WriteLine("Ingrese el nombre de los productos que quiere agregar al carrito uno por uno (si no quiere agregar mas, escriba salir)");
            string nameProductShopee = Console.ReadLine();
            var exist = shoppings.FirstOrDefault(p => p.name.Equals(nameProductShopee, StringComparison.OrdinalIgnoreCase));
            //exist.amount = 0;
            
            if (nameProductShopee == "salir")
            {                

                outAddProductsCarShopee = false;
                Console.WriteLine("Asì esta tu carrito en este momento");
                foreach (Product n in shoppings)
                {
                Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Nombre: {n.name} \n Precio: {n.price} \n Cantidad: {n.amount}");
                    totalPrice +=  n.price;
                Console.WriteLine("--------------------------------------------");
                    
                }
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"Total : {totalPrice} ");
            }

            foreach (var y in products)
            {
                if (y.name == nameProductShopee && y.amount == 0)
                {
                    Console.WriteLine("No hay de este producto, intentelo de nuevo");
                }
                else if (y.name == nameProductShopee)
                {
                    if (exist != null)
                    {
                        
                        exist.amount  += 1;
                        
                    } 
                    
                y.amount = y.amount - 1;
                var productForshopeeAmount = (products.Find(p => p.name == nameProductShopee));
                productForshopeeAmount.amount = 0;
                shoppings.Add(productForshopeeAmount);
                Console.WriteLine($"Se ha agregado {nameProductShopee} al carrito");
                
                
                
                

                }
                
            }
            
            
          
            }
            
            break;
        case 2:
             Console.WriteLine("---FACTURA---");
            Console.WriteLine("----------------------------------------------------------------");
            foreach (Product s  in shoppings)
            {
                Console.WriteLine($"Nombre: {s.name} \n Precio: {s.price} \nCantidad: {s.amount}");
            }
            break;
    }
    }

}


 void Crud_admin()
 {
     bool returAdmiMenu = true;
     
     while (returAdmiMenu){
     Console.WriteLine("Hola admin, que desea hacer? \n 1. crear un producto \n 2. editar un producto \n 3. eliminar un producto \n 4. ver todos los productos \n 5. Salir");;
     int optionsAdmin =  int.Parse(Console.ReadLine());

     switch (optionsAdmin)
     {
         case 1:
             Console.WriteLine("Ingrese el nombre del producto: ");
             string createProductName  = Console.ReadLine();
             Console.WriteLine("Ingrese el precio del producto: ");
             double createPriceProduct = double.Parse(Console.ReadLine());
             Console.WriteLine("Ingrese la cantidad en inventario del producto: ");
             int createAmountProduct = int.Parse(Console.ReadLine());
             
             products.Add(new Product(createProductName, createPriceProduct, createAmountProduct));
             break;
         case 2:
           
                 
             Console.WriteLine("Ingrese el nombre del producto que desea  modificar: ");
             string modifyProductName = Console.ReadLine();
             int indexEditProduct = products.FindIndex(p =>p.name == modifyProductName);
             bool modifyMore = true;
             while (modifyMore)
             {
                 Console.WriteLine("Que desea modificar del producto \n 1. Nombre \n 2. Precio \n 3. Cantidad \n 4. Salir");
                 int crudOptionsProduct = int.Parse(Console.ReadLine());
                 switch (crudOptionsProduct)
                 {
                     case 1: 
                         Console.WriteLine("Ingrese el nuevo nombre del producto: ");
                         string newProductName = Console.ReadLine();
                         products[indexEditProduct].name = newProductName;
                         
                         break;
                     case 2:
                         Console.WriteLine("Ingrese el nuevo precio del producto: ");
                         double newProductprice = double.Parse(Console.ReadLine());
                         products[indexEditProduct].price = newProductprice;
                         break;
                     case 3: 
                         Console.WriteLine("Actualice la cantidad del producto: ");
                         int newProductAmount = int.Parse(Console.ReadLine());
                         products[indexEditProduct].amount = newProductAmount;
                         break;
                     case 4:
                         modifyMore = false;
                         break;
                 }
             
             
                 
             }
             
             break;
         case 3 :
             Console.WriteLine("Ingrese el nombre del producto que desea  eliminar: ");
             string deleteProductName = Console.ReadLine();
             int indexDeleteProduct = products.FindIndex(p =>p.name == deleteProductName);
             Console.WriteLine($"Seguro que quiere eliminar {deleteProductName} (si/no)");
             string sureDelete = Console.ReadLine();

             if (sureDelete == "si")
             {
                 products.RemoveAt(indexDeleteProduct);
                 Console.WriteLine("El producto eliminado exitosamente");
             } 
             break;
         case 4 :
             foreach (var productView in products)
             {
                 Console.WriteLine($" Nombre: {productView.name} \n Precio:{productView.price} \n Cantidad: ${productView.amount}");
                 Console.WriteLine("----------------------");
             }
             break;
         case 5:
             returAdmiMenu = false;
             break;
     }
     }
}


class Product
{   
    public string name {get; set;}
    public double price {get; set;}
    public int amount {get; set;}

    public Product(string createProductName, double createPriceProduct, int createAmountProduct)
    {
        this.name = createProductName;
        this.price = createPriceProduct;
        this.amount = createAmountProduct;
    }
}


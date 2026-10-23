using System.Net.Security;
//using static System.Net.WebRequestMethods;
using System.IO;
bool running = true;
List<string> validProducts = new List<string>();
bool skipPause = false;

while (running)
{
    skipPause = false;
    Console.WriteLine("======================================");
    Console.WriteLine("  PRODUCT INVENTORY SYSTEM - LEVEL 4  ");
    Console.WriteLine("======================================");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. View Products");
    Console.WriteLine("3. Search Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Statistics");
    Console.WriteLine("6. Exit");
    Console.WriteLine();
    Console.WriteLine();
    Console.Write("Select option: ");
    string choice = Console.ReadLine().Trim();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            //Console.WriteLine("Select option: 1");
            //Console.Write("Enter product or type exit to return to menu: ");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter Product or type exit to return to menu: ");
                string input = Console.ReadLine().Trim();


                // 1. Validar si está vacío
                if (input == null || input == "")
                {
                    Console.WriteLine("ERROR:Input cannot be empty.\n");
                    continue;
                }

                // 2. Salir al menú principal si escribe 'exit'
                if (input.ToLower().Trim() == "exit")
                {
                    skipPause = true; // Evita la pausa antes de limpiar la pantalla    
                    break;
                }

                // 3. Verificar estructura con guion
                string[] parts = input.Split('-');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid format. Product must contain a dash (-)");
                    continue;
                }

                string leftSide = parts[0];
                string rightSide = parts[1];

                // 4. Validar lado izquierdo (solo letras)
                if (leftSide == null || leftSide == "" || leftSide.All(char.IsLetter) == false)
                {
                    Console.WriteLine("ERROR:The left side must contain letters only.");
                    continue;
                }

                // 5. Validar lado derecho (solo números)
                if (rightSide == null || rightSide == "" || rightSide.All(char.IsDigit) == false)
                {
                    Console.WriteLine("ERROR: The right side must contain numbers only.\n");
                    continue;
                }

                // 6. Validar rango numérico (200 - 500)
                int numericValue = int.Parse(rightSide);
                if (numericValue < 200 || numericValue > 500)
                {
                    Console.WriteLine("ERROR: The numeric part must be between 200 and 500.\n");
                    continue;
                }
                // 7 . Validar duplicados
                bool isDuplicate = false;
                foreach (string product in validProducts)
                {
                    if (product.ToLower() == input.Trim().ToLower())
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (isDuplicate)
                {
                    Console.WriteLine("ERROR: This product already exists in the list.\n");
                    continue;
                }

                // If all is correct, add the product to the list
                // normalice input to uppercase for consistent storage and comparison
                input = input.ToUpper();
                validProducts.Add(input.Trim());
                Console.WriteLine($"Product added successfully: {input.Trim()}\n");
            }
            break;

        case "2":
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Registered Products: ");
            if (validProducts.Count == 0)
            {
                Console.WriteLine("No products registered yet.\n");
            }
            else
            {
                validProducts.Sort();
                foreach (var prod in validProducts)
                {
                    Console.WriteLine("- " + prod);
                }
                Console.WriteLine();
            }
            break;

        case "3":
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            Console.Write("Search product: ");
            string searchTerm = Console.ReadLine().Trim();

            if (searchTerm == null || searchTerm == "")
            {
                Console.WriteLine("Search term cannot be empty.\n");
                break;
            }

            Console.WriteLine("\nResults:");
            bool found = false;
            foreach (var prod in validProducts)
            {
                if (prod.ToLower().Contains(searchTerm.ToLower()))
                {
                    Console.WriteLine($"- {prod}");
                    found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("No matching products found.\n");
            }
            break;


        case "4":
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            Console.Write("Enter product to delete: ");
            string productToDelete = Console.ReadLine().Trim();

            string productMatch = null;
            foreach (var prod in validProducts)
            {
                if (prod.ToLower() == productToDelete.ToLower())
                {
                    productMatch = prod;
                    break;
                }
            }

            if (productMatch != null)
            {
                validProducts.Remove(productMatch);
                Console.WriteLine("Product removed successfully.\n");
            }
            else
            {
                Console.WriteLine("ERROR: Product not found.\n");
            }
            break;

        case "5":
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Statistics:");
            if (validProducts.Count == 0)
            {
                Console.WriteLine("No products available to calculate statistics.\n");
            }
            else
            {
                int totalProducts = validProducts.Count;
                int highest = int.MinValue;
                int lowest = int.MaxValue;
                int sum = 0;

                foreach (var prod in validProducts)
                {
                    string[] parts = prod.Split('-');
                    int num = int.Parse(parts[1]);

                    if (num > highest) highest = num;
                    if (num < lowest) lowest = num;
                    sum += num;
                }

                int average = sum / totalProducts;

                Console.WriteLine($"- Total Products: {totalProducts}");
                Console.WriteLine($"- Lowest Number: {lowest}");
                Console.WriteLine($"- Highest Number: {highest}");
                Console.WriteLine($"- Average Number: {average}\n");
            }
            break;

        case "6":
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Saving products...");
            File.WriteAllLines("products.txt", validProducts);
            Console.WriteLine("Application closed.");
            running = false; // Cambia a false para romper el bucle y terminar el programa
            break;

        default:
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("-> Invalid option. Please choose between 1 and 6.");
            break;
    }

    // Pausa antes de limpiar la pantalla y volver a mostrar el menú
    if (running && !skipPause)
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
    else if (running && skipPause)
    {
        Console.Clear();
    }
}
# Product Inventory System - Level 4

> A C# console application for managing, validating, analyzing, and persisting product inventory data locally.

---

## Key Features

The system provides an interactive menu with the following features:

1. **Add Product:** Register new products while applying strict real-time validation rules.
2. **View Products:** Display the complete list of registered products sorted alphabetically.
3. **Search Product:** Search for products using partial matching (case-insensitive).
4. **Delete Product:** Search for and remove existing products from the system.
5. **Statistics:** Calculate key metrics based on product numeric values (Total products, lowest value, highest value, and average value).
6. **Save & Exit:** Automatically saves all registered products to a local text file (`products.txt`) and exits the application.

---

## 🔒 Product Validation Rules

To ensure data integrity when adding a product (**Option 1**), the input must satisfy the following conditions:
* **Format:** Must contain a hyphen (`-`) separating two parts (e.g., `LAPTOP-300`).
* **Left Side:** Must contain letters only (alphabetic).
* **Right Side:** Must contain numbers only (digits).
* **Numeric Range:** The numeric value on the right side must be between **200 and 500** (inclusive).
* **Duplicates:** Duplicate entries are strictly prevented (case-insensitive check).
* **Normalization:** All valid product codes are automatically converted and stored in **UPPERCASE**.

---

## 📋 Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) (Compatible with .NET 6.0, 7.0, or 8.0+).
* An IDE or terminal capable of running C# projects (such as Visual Studio, Visual Studio Code, or standard command line).

---

## ⚙️ How to Run

1. Clone or download this repository to your local machine.
2. Open your terminal and navigate to the project root directory.
3. Execute the following command to build and run the application:
   ```bash
   dotnet run

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MiniAutomationToolkit.Core.Models;

namespace MiniAutomationToolkit.Core.Repositories
{
    public static class ProductRepository
    {
        public static List<Product> LoadFromCsv(string filePath)
        {
            var products = new List<Product>();

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(';');

                if (parts.Length != 3)
                {
                    throw new InvalidDataException($"Invalid info on line {i + 1}");
                }

                string name = parts[0].Trim();
                string priceText = parts[1].Trim();
                string categoryText = parts[2].Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(priceText) || string.IsNullOrEmpty(categoryText))
                {
                    throw new InvalidDataException($"Invalid data at line {i + 1}");
                }
                if (!decimal.TryParse(priceText, out decimal price))
                {
                    throw new InvalidDataException($"Invalid data at line {i + 1}");
                }
                if (price < 0)
                {
                    throw new InvalidDataException($"Invalid data at line {i + 1}");
                }
                if (!Enum.TryParse(categoryText, true, out ProductCategory category))
                {
                    throw new InvalidDataException($"Invalid data at line {i + 1}");
                }

                products.Add(new Product(name, price, category));
            }

            return products;
        }

        public static List<string> GetAffordableProducts(
            IEnumerable<Product> products,
            ProductCategory category,
            decimal maxPrice)
        {
            return products
                .Where(p => p.Category == category)
                .Where(p => p.Price < maxPrice)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .Select(p => p.Name)
                .ToList();
        }
    }
}
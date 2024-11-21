using System;
using System.Collections.Generic;

namespace WarehouseManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Словарь для хранения товаров и их количества
            Dictionary<string, int> warehouse = new Dictionary<string, int>
            {
                { "Яблоки", 10 },
                { "Бананы", 15 },
                { "Груши", 8 },
                { "Апельсины", 12 },
                { "Мандарины", 20 }
            };

            while (true)
            {
                try
                {
                    // Отображение товаров на складе
                    Console.WriteLine("\nТовары на складе:");
                    foreach (var item in warehouse)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value} шт.");
                    }

                    // Запрос на выбор товара
                    Console.Write("\nВведите название товара для списания: ");
                    string productName = Console.ReadLine();

                    // Проверяем, есть ли товар на складе
                    if (!warehouse.ContainsKey(productName))
                    {
                        Console.WriteLine($"Ошибка: товар \"{productName}\" не найден.");
                        continue;
                    }

                    // Запрос количества для списания
                    Console.Write($"Введите количество для списания (доступно {warehouse[productName]} шт.): ");
                    int quantityToRemove = int.Parse(Console.ReadLine());

                    // Проверяем на корректное количество
                    if (quantityToRemove <= 0)
                    {
                        Console.WriteLine("Ошибка: количество должно быть больше 0.");
                        continue;
                    }
                    if (quantityToRemove > warehouse[productName])
                    {
                        Console.WriteLine("Ошибка: недостаточно товара на складе.");
                        continue;
                    }

                    // Списываем товар
                    warehouse[productName] -= quantityToRemove;
                    Console.WriteLine($"Списано {quantityToRemove} шт. товара \"{productName}\". Осталось: {warehouse[productName]} шт.");

                    // Если товара не осталось, удаляем его из словаря
                    if (warehouse[productName] == 0)
                    {
                        warehouse.Remove(productName);
                        Console.WriteLine($"Товар \"{productName}\" полностью списан со склада.");
                    }
                }
                catch (FormatException)
                {
                    // Обработка ошибки неверного формата ввода
                    Console.WriteLine("Ошибка: введите числовое значение для списания.");
                }
                catch (Exception ex)
                {
                    // Обработка всех других ошибок
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                }
                finally
                {
                    // Этот блок выполнится всегда
                    Console.WriteLine("Операция завершена.");
                }
            }
        }
    }
}


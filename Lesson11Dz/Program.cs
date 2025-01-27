using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Lesson11Dz.Models;


class Program
{
    private static readonly string filePath = "users.txt";
    private static List<User> users = new List<User>();

    static void Main(string[] args)
    {

        AddUser("Артур Ауг", 30, "arturaug@gmail.com");
        AddUser("Дима Иванов", 25, "dimaivanov@gmail.com");
        AddUser("Игарь бабкин", 40, "ighorbabkin@gmail.com");

        
        bool running = true;
        while (running)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Показать всех пользователей");
            Console.WriteLine("3. Загрузить пользователей из файла");
            Console.WriteLine("4. Завершить программу");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddUserInteractive();
                    SaveUsersToFile();
                    break;
                case "2":
                    ShowUsers();
                    break;
                case "3":
                    LoadUsersFromFile();                    
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }
        }
        
    }

    static void AddUser(string name, int age, string email)
    {
        users.Add(new User { Name = name, Age = age, Email = email });
    }

    static void AddUserInteractive()
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();
        Console.Write("Введите возраст: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Введите электронную почту: ");
        string email = Console.ReadLine();
        AddUser(name, age, email);
        Console.WriteLine("Пользователь добавлен.");
    }

    static void ShowUsers()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("Список пользователей пуст.");
        }
        else
        {
            Console.WriteLine("Список пользователей:");
            foreach (var user in users)
            {
                Console.WriteLine($"Имя: {user.Name}, Возраст: {user.Age}, Email: {user.Email}");
            }
        }
    }

    static void SaveUsersToFile()
    {
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Список пользователей сохранен в файл.");
    }

    static void LoadUsersFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            users = JsonSerializer.Deserialize<List<User>>(json);
            Console.WriteLine("Список пользователей загружен из файла.");
        }
        else
        {
            Console.WriteLine("Файл с пользователями не найден.");
        }
    }
}
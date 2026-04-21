using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Lab_5__Net_technologies_;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        using (var db = new AppDbContext())
        {
            // Створюємо базу, якщо її ще немає
            db.Database.EnsureCreated();

            Console.WriteLine("=== ОПЕРАЦІЯ ДОДАВАННЯ КОРИСТУВАЧІВ ===");

            // Список користувачів, яких ми хочемо бачити в базі
            var usersToAdd = new List<User>
            {
                new User { FirstName = "Іван", LastName = "Петренко", Email = "ivan@gmail.com" },
                new User { FirstName = "Марія", LastName = "Іваненко", Email = "maria@gmail.com" },
                new User { FirstName = "Олексій", LastName = "Коваленко", Email = "oleksiy.dev@ukr.net" },
                new User { FirstName = "Валерія", LastName = "Сорокіна", Email = "valeriia@univ.net" } // Твій новий користувач
            };

            int addedCount = 0;

            foreach (var newUser in usersToAdd)
            {
                // Перевіряємо, чи є вже в базі користувач з таким Email
                bool exists = db.Users.Any(u => u.Email == newUser.Email);

                if (!exists)
                {
                    db.Users.Add(newUser);
                    Console.WriteLine($"Додано: {newUser.FirstName} ({newUser.Email})");
                    addedCount++;
                }
            }

            if (addedCount > 0)
            {
                db.SaveChanges();
                Console.WriteLine($"\nУспішно додано нових користувачів: {addedCount}");
            }
            else
            {
                Console.WriteLine("\nВсі вказані користувачі вже існують у базі. Нічого не додано.");
            }

            Console.WriteLine("\n=== ПОТОЧНИЙ СПИСОК У БАЗІ ===");
            var allUsers = db.Users.ToList();
            foreach (var u in allUsers)
            {
                Console.WriteLine($"{u.Id}. {u.FirstName} {u.LastName} - {u.Email}");
            }
        }

        Console.ReadLine();
    }
}
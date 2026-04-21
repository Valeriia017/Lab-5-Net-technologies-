using System;
using System.Linq;
using System.Text;
using Lab_5__Net_technologies_;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        using (var db = new AppDbContext())
        {
            // Закоментуй або видали EnsureDeleted, якщо хочеш, щоб дані зберігалися між запусками
            // db.Database.EnsureDeleted(); 
            db.Database.EnsureCreated();

            Console.WriteLine("=== ПЕРЕВІРКА ТА ДОДАВАННЯ КОРИСТУВАЧІВ ===");

            // Перевіряємо, чи таблиця Users порожня
            if (!db.Users.Any())
            {
                var user1 = new User { FirstName = "Іван", LastName = "Петренко", Email = "ivan@gmail.com" };
                var user2 = new User { FirstName = "Марія", LastName = "Іваненко", Email = "maria@gmail.com" };
                var user3 = new User { FirstName = "Олексій", LastName = "Коваленко", Email = "oleksiy.dev@ukr.net" };

                db.Users.AddRange(user1, user2, user3); // Можна додавати групою
                db.SaveChanges();
                Console.WriteLine("Нових користувачів додано до порожньої бази!\n");
            }
            else
            {
                Console.WriteLine("Користувачі вже існують у базі. Нові записи не додано.\n");
            }

            Console.WriteLine("=== СПИСОК КОРИСТУВАЧІВ У БАЗІ ===");
            var users = db.Users.ToList();
            foreach (var u in users)
            {
                Console.WriteLine($"{u.Id}. {u.FirstName} {u.LastName} - {u.Email}");
            }
        }

        Console.ReadLine();
    }
}
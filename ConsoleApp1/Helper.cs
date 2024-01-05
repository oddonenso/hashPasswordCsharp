using System;
using System.Linq;
using System.Data.Entity;
using ConsoleApp1.Models;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Helper
    {
        private static PhotoStudioEntities2 s_firstDBentities;

        public Helper()
        {
            s_firstDBentities = new PhotoStudioEntities2();
        }

        public void CreateUsers(clients clients)
        {
            PhotoStudioEntities2 context = GetContext();
            context.clients.Add(clients);
            context.SaveChanges();
        }

        public void UpdateUsers(clients clients)
        {
            Console.WriteLine("Enter new name: ");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter new surname: ");
            string newSurname = Console.ReadLine();
            Console.WriteLine("Enter new email: ");
            string newEmail = Console.ReadLine();

            clients newClient = new clients()
            {  
                surname = newSurname,
                email = newEmail
            };

            s_firstDBentities.Entry(clients).CurrentValues.SetValues(newClient);
            s_firstDBentities.SaveChanges();
        }

        public void DeleteUsers(clients clients)
        {

            var clientToDelete = s_firstDBentities.clients.SingleOrDefault(c => c.id == clients.id);
            if (clientToDelete != null)
            {
                s_firstDBentities.clients.Remove(clientToDelete);
                s_firstDBentities.SaveChanges();
            }
        }

        public void FindUsers(clients clients)
        {
            var users = s_firstDBentities.clients
                .Where(c => c.name == clients.name && c.surname == clients.surname && c.email == clients.email)
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine("User ID: {0}, Name: {1}, Surname: {2}, Email: {3}", user.id, user.name, user.surname, user.email);
            }
        }

        public void SortUsers(clients clients)
        {
            var sortedUsers = s_firstDBentities.clients.OrderBy(u => u.surname)//обращение к сущности
                .Where(c => c.name == clients.name && c.surname == clients.surname && c.email == clients.email)
                .ToList();//сортировка по возрастанию, фильтрование записи, чтобы совпадали с clients

            foreach (var user in sortedUsers)
            {
                Console.WriteLine("User ID: {0}, Name: {1}, Surname: {2}, Email: {3}", user.id, user.name, user.surname, user.email);
            }
        }

        private static PhotoStudioEntities2 GetContext()//возвращение контекста базы данных
        {
            return s_firstDBentities ?? throw new InvalidOperationException("Context is null");//?? если равен нулю
        }
        //гарантирует, что у вас не будет нулевого контекста базы данных

        public string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;

        }
    }
}

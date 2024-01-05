using ConsoleApp1.Models;
using System;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Helper helper = new Helper();
            clients newClient = new clients();
            Registration registration = new Registration();
            Helper2 helper2 = new Helper2();

            Console.WriteLine("Введите имя: ");
            newClient.name = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            newClient.surname = Console.ReadLine();
            Console.WriteLine("Введите почту: ");
            newClient.email = Console.ReadLine();
            Console.WriteLine("Введите парольчик");
            registration.password_user = Console.ReadLine();

            helper.CreateUsers(newClient);

            using (var context = new PhotoStudioEntities2())
            {
                var allClients = context.clients.ToList();
                foreach (var client in allClients)
                {
                    Console.WriteLine($"Имя: {client.name}");
                    Console.WriteLine($"Фамилия: {client.surname}");
                    Console.WriteLine($"Email: {client.email}");
                }

                helper2.CreatePassword(registration);
                using (var sas = new PhotoStudioEntities2())
                {
                    var allpassword = sas.Registration.ToList();
                    foreach(var password in allpassword)
                    {
                        Console.WriteLine($"Парольчик:{password.HashPassword(password.password_user)}");
                    }
                }
                helper2.CreatePassword(registration);
            }
        }
    }
}

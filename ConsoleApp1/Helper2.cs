using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Helper2
    {
        private static PhotoStudioEntities2 s_firstDBentities;

        public Helper2()
        {
            s_firstDBentities = new PhotoStudioEntities2();
        }
        public string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var pbkdf = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }
        public void CreatePassword(Registration registration)
        {
            using (var context = new PhotoStudioEntities2())
            {
                try
                {
                    if (context.Registration.Any(r => r.password_user == registration.password_user))
                    {
                        Console.WriteLine("Пароль уже существует");
                    }
                    else
                    {
                        registration.password_user = HashPassword(registration.password_user); // Хэшируем пароль
                        context.Registration.Add(registration);
                        context.SaveChanges();
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }
                }
            }
        }

    }

}

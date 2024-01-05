using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using pr_3.Models;

namespace ConsoleApp1
{
    internal class Helpr
    {
        private static PhotoStudioEntities s_firstDBentities;

        public static PhotoStudioEntities GetContext()
        {
            if (s_firstDBentities == null)
            {
                s_firstDBentities = new PhotoStudioEntities();
            }

            return s_firstDBentities;
        }
        public void CreateUsers(clients clients)
        {
            s_firstDBentities.clients.Add(clients);
            s_firstDBentities.SaveChanges();
        }
        public void UpdateUsers(clients clients)
        {
            s_firstDBentities.Entry(clients).State = EntityState.Modified;
            s_firstDBentities.SaveChanges();
        }
        public void DeleteUsers(clients clients)
        {
            var cluent = s_firstDBentities.User.Find(clients);
            s_firstDBentities.User.Remove(cluent);
            s_firstDBentities.SaveChanges();
        }
        public void FindUsers()
        {
            var cluent = s_firstDBentities.clients.Where(x => x.name.StartsWith("Е") || x.name.StartsWith("N"));
        }
        public void SortUsers()
        {
            var cluent = s_firstDBentities.clients.OrderBy(x => x.surname);
        }
    }
}

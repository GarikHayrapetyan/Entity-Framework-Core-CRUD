using System;
using System.Linq;

namespace EFCORE
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User { Id=1, Name = "Tom", Age = 22 };
            User user1 = new User { Id=2, Name = "Sam", Age = 21 };

            Company company = new Company { Name = "Samsung" };
            Phone phone = new Phone { Name="A6 2018",Price=850,Manufacturer=company};

            using (AppContext db = new AppContext())
            {
                db.Phones.Add(phone);
                db.SaveChanges();
            }

                Console.ReadKey();
        }


        static void Add(params User[] users)
        {
            using (AppContext db = new AppContext()) {
                db.Add(users);
                db.SaveChanges();
            }
        }

        static void Delete(params User[] users)
        {
            using (AppContext db = new AppContext())
            {
                foreach(User user in users)
                {
                   db.Users.Remove(user);
                }
                
                db.SaveChanges();
            }
        }

        static void Read(){

            using (AppContext db = new AppContext())
            {
                var users = db.Users.ToList();
                foreach(User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}

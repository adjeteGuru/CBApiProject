using CBApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBApi.Database
{
    public static class CBApiSeedData
    {
        public static void EnsureSeedData(this CBApiContext db)
        {
            if (!db.Users.Any())
            {
                var users = new List<User>
                {
                    new User

                    {   UserName = "admin",
                        Password="12345",
                        CreatedAt=DateTime.Parse("2020-03-04")
                    }

                };
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Csabamotor.Web.Models
{
    public static class DbInitializer
    {
        public static void Initialize(CsabamotorDBContext context, string imageDirectory)
        {
            // Use only one of the below.
            // Create / update database based on migration classes.

            //context.Database.Migrate();
            // Create database if not exists based on current code-first model (no migrations!).
            context.Database.EnsureCreated();

            if (context.Lists.Any())
            {
                return;
            }

            string ScooterPath = Path.Combine(imageDirectory, "sampleScooter.jpg");
            string WheelPath = Path.Combine(imageDirectory, "fakerek.jpg");

            IList<List> defaultLists = new List<List>
            {
                new List
                {
                    Name = "Robogók",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Honda Term-Inátór",
                            Price=100000,
                            Description = "Megkíméletlen állapot",
                            UploadTime = DateTime.Now,
                            Image = File.Exists(ScooterPath) ? File.ReadAllBytes(ScooterPath) : null

                        },
                        new Item()
                        {
                            Name = "To Yoda",
                            Price=150000,
                            Description = "Megkíméletlen állapot",
                            UploadTime = DateTime.Now,
                            Image = File.Exists(ScooterPath) ? File.ReadAllBytes(ScooterPath) : null
                        },
                    }
                },
                new List
                {
                    Name = "Alkatrészek",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Fakerék",
                            Price = 5000,
                            Description = "Megbízható tüzelőanyag!",
                            UploadTime = DateTime.Now,
                            Image = File.Exists(WheelPath) ? File.ReadAllBytes(WheelPath) : null
                        }
                    }
                }
            };

            context.AddRange(defaultLists);
            context.SaveChanges();
        }
    }
}


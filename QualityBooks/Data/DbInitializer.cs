using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QualityBooks.Models;

namespace QualityBooks.Data
{
    public static class DbInitializer
    {
       
        public static void Initialize(QualityBooksContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Categories.Any())
            {
                return; // DB has been seeded
            }

            var categories = new Category[]
            {
                new Category{CategroyName="Arts & Music"},
                new Category{CategroyName="Business"},
                new Category{CategroyName="Sports"},
                new Category{CategroyName="Maori Culture"},
            };

            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var suppliers = new Supplier[]
            {
                new Supplier{FirstName="Richard",LastName="Conway",HomePhoneNo="21553555",MobileNo="21333377",Email="richard@email.com"},
                new Supplier{FirstName="Mike",LastName="Ballard",HomePhoneNo="210000000",MobileNo="25555577",Email="mike@email.com"},
                new Supplier{FirstName="Peter",LastName="Russell",HomePhoneNo="23333377",MobileNo="25677777",Email="peter@email.com"},
            };

            foreach (Supplier s in suppliers)
            {
                context.Suppliers.Add(s);
            }
            context.SaveChanges();
    
            string path = Environment.CurrentDirectory + @"/wwwroot/images/Temp/defaultBook.jpg";
            byte[] image = System.IO.File.ReadAllBytes(path);

            var Product = new Product[]
            {
                new Product{CategoryId=1, Description="This is Book about Maori History", ProductImage=image, ProductName="Maori History ", ProductPrice=45, SupplierId=1 }
                
            };
            foreach (Product b in Product)
            {
                context.Products.Add(b);
            }
            context.SaveChanges();



        }
    }
}
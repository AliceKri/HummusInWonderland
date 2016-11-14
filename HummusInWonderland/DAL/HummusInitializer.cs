﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using HummusInWonderland.Models;

namespace HummusInWonderland.DAL
{
    public class HummusInitializer : System.Data.Entity.DropCreateDatabaseAlways<HummhusInWonderlandContext>
    {
        protected override void Seed(HummhusInWonderlandContext context)
        {
           var menu = new List<Product>
            {
                new Product { ProductID = 1,   ProductName = "חומוס בשר",
                    ProductDescription = "חומוס עם בשר בקר טחון, גרגרים, פטרוזיליה, שמן זית, כמון, פפריקה, 2פיתות, חמוצים",
                Price = 38, ProductImage = "/Images/hummus_meat_top.png", Vegi = false, Orders = new List<Order>()},
                new Product { ProductID = 2,   ProductName = "חומוס פטריות",
                    ProductDescription = "חומוס עם פטריות שלמות, מבושלות עם בצל ותבלינים. מוגש עם גרגרים, פטרוזיליה, שמן זית, כמון, פפריקה, 2פיתות, חמוצים",
                Price = 34, ProductImage = "/Images/hummus_mushroom_top.png", Vegi = true, Orders = new List<Order>()},
                new Product { ProductID = 3,   ProductName = "חומוס צנובר",
                    ProductDescription = "חומוס עם צנובר קלוי בתנור, מוגש עם גרגרים, פטרוזיליה, שמן זית, כמון, פפריקה, 2פיתות, חמוצים",
                Price = 34, ProductImage = "/Images/hummus_tznubar_top.png", Vegi = true, Orders = new List<Order>() },
                new Product { ProductID = 4,   ProductName = "חומוס",
                    ProductDescription = "חומוס עם גרגרים, פטרוזיליה, שמן זית, ביצה, כמון, פפריקה, 2פיתות, חמוצים",
                Price = 25, ProductImage = "/Images/hummus_top.png", Vegi = true, Orders = new List<Order>()},
                new Product { ProductID = 5,   ProductName = "חומוס פול",
                    ProductDescription = "חומוס עם פול גרגרים, פטרוזיליה, שמן זית, ביצה, כמון, פפריקה, , 2פיתות, חמוצים",
                Price = 25,ProductImage = "/Images/hummus_ful_top.png", Vegi = true, Orders = new List<Order>()},
                new Product { ProductID = 6,   ProductName = "חומוס משאוושה",
                    ProductDescription = "משוואשה על חומוס מוגשת עם גרגרים, פטרוזיליה, שמן זית, ביצה, כמון, פפריקה, 2פיתות, חמוצים",
                Price = 25,ProductImage = "/Images/mashausha_top.png", Vegi = true, Orders = new List<Order>()},
                new Product { ProductID = 7,   ProductName = "המשולשת",
                    ProductDescription = "1/3חומוס 1/3משוואשה 1/3פול, מוגשת עם גרגרים, פטרוזיליה, שמן זית, ביצה, כמון, פפריקה, 2פיתות, חמוצים",
                Price = 25,ProductImage = "/Images/hummus_tri_top.png", Vegi = true, Orders = new List<Order>()},
                new Product { ProductID = 8,   ProductName = "מנה סלט",
                    ProductDescription = "מנת סלט עם חומוס, טחינה, גרגרים, וביצה",
                Price = 25,ProductImage = "/Images/hummus_salad_front.png", Vegi = true, Orders = new List<Order>()},

            };
            menu.ForEach(p => context.Menu.Add(p));
            context.SaveChanges();

            var customer = new List<Customer>
            {
                new Customer {CustomerID = 1, FirstName = "דניאל", LastName ="יעקובסן", BirthDate = DateTime.Parse("1994-08-13") ,
                Gender = Gender.זכר, Email = "halleldaniel@gmail.com", City ="ראש העין", Street = "חבצלת", Password ="123456", PhoneNumber = "0543034020"},
                new Customer {CustomerID = 2, FirstName = "עמית", LastName ="הררי", BirthDate = DateTime.Parse("1993-11-19") ,
                Gender = Gender.זכר, Email = "amit.harari93@gmail.com", City ="תל אביב", Street = "אבן גבירול", Password ="123456", PhoneNumber = "0528465750"},
                new Customer {CustomerID = 3, FirstName = "עליסה", LastName ="קריבורוצקי", BirthDate = DateTime.Parse("1994-03-11") ,
                Gender = Gender.נקבה, Email = "alisa6450@gmail.com", City ="באר שבע", Street = "גלזמן", Password ="123456", PhoneNumber = "0543016142"},
                new Customer {CustomerID = 4, FirstName = "שחר", LastName ="חסון", BirthDate = DateTime.Parse("1980-09-17") ,
                Gender = Gender.זכר, Email = "shaharhason@gmail.com", City ="תימן", Street = "תימנים", Password ="123456", PhoneNumber = "0507878787"},
                new Customer {CustomerID = 5, FirstName = "אדיר", LastName ="מילר", BirthDate = DateTime.Parse("1983-04-12") ,
                Gender = Gender.זכר, Email = "adirmiller@gmail.com", City ="פתח תקווה", Street = "כלנית", Password ="123456", PhoneNumber = "0526767489"},
                new Customer {CustomerID = 6, FirstName = "בר", LastName ="רפאלי", BirthDate = DateTime.Parse("1985-09-13"),
                Gender = Gender.נקבה, Email = "barrefaeli@gmail.com", City ="תל אביב", Street = "הדוגמנויות", Password ="123456", PhoneNumber = "0526839072"},
                new Customer {CustomerID = 7, FirstName = "גל", LastName ="גדות", BirthDate = DateTime.Parse("1986-02-18") ,
                Gender = Gender.נקבה, Email = "galgadot@gmail.com", City ="תל אביב", Street = "הדוגמנויות", Password ="123456", PhoneNumber = "0508362973"}
            };
            customer.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            /**
            var orders = new List<Order>
            {
                new Order { OrderID = 1, CustomerId = customer.Single(s => s.LastName == "דניאל").CustomerID, ProductID = menu.Single(s => s.ProductName == "חומוס").ProductID, OrderDate = DateTime.Parse("2016-02-14"), TotalPrice= 25},
                new Order { OrderID = 2, CustomerId = customer.Single(s => s.LastName == "יעקובסן").CustomerID, ProductID = menu.Single(s => s.ProductName == "חומוס פול").ProductID, OrderDate = DateTime.Parse("2016-03-14"), TotalPrice= 25},
                new Order { OrderID = 3, CustomerId = customer.Single(s => s.LastName == "רפאלי").CustomerID, ProductID = menu.Single(s => s.ProductName == "חומוס בשר").ProductID, OrderDate = DateTime.Parse("2016-04-14"), TotalPrice= 2},
                new Order { OrderID = 4, CustomerId = customer.Single(s => s.LastName == "הררי").CustomerID, ProductID = menu.Single(s => s.ProductName == "המשולשת").ProductID, OrderDate = DateTime.Parse("2016-05-14"), TotalPrice= 38},
                new Order { OrderID = 5, CustomerId = customer.Single(s => s.LastName == "קריבורוצקי").CustomerID, ProductID = menu.Single(s => s.ProductName == "מנה סלט").ProductID, OrderDate = DateTime.Parse("2016-05-14"), TotalPrice= 34},
                new Order { OrderID = 6, CustomerId = customer.Single(s => s.LastName == "מילר").CustomerID, ProductID = menu.Single(s => s.ProductName == "חומוס משאוושה").ProductID, OrderDate = DateTime.Parse("2016-06-14"), TotalPrice= 25},
                new Order { OrderID = 7, CustomerId = customer.Single(s => s.LastName == "מילר").CustomerID, ProductID = menu.Single(s => s.ProductName == "חומוס").ProductID, OrderDate = DateTime.Parse("2016-06-14"), TotalPrice= 34}

            };
            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();

            // todo: is it right?
            foreach (Customer c in customer)
            {
                c.Orders = new List<Order>();
                foreach(Order o in orders)
                {
                    if(o.CustomerId == c.CustomerID){
                        c.Orders.Add(o);
                    }
                }
            }
            customer.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();**/

            var branch = new List<Branch>
            {
                new Branch {BranchID = 1, BranchCity= "תל אביב", BranchName = "חומוס פלא", BranchsHouseNumber = 3,BranchsPhoneNumber = "03-4678953", BranchStreet = "אבן גבירול" },
                new Branch {BranchID = 2, BranchCity= "ירושלים", BranchName = "חומוס פלא", BranchsHouseNumber = 12,BranchsPhoneNumber = "04-7895034", BranchStreet = "שלמה המלך" },
                new Branch {BranchID = 3, BranchCity= "באר שבע", BranchName = "חומוס פלא", BranchsHouseNumber = 56,BranchsPhoneNumber = "08-6457890", BranchStreet = "אברהם אבינו" },
                new Branch {BranchID = 4, BranchCity= "חיפה", BranchName = "חומוס פלא", BranchsHouseNumber = 34,BranchsPhoneNumber = "09-8765942", BranchStreet = "פרחים" }
            };
            branch.ForEach(b => context.Branches.Add(b));
            context.SaveChanges();
        }
    }
}
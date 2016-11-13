namespace HummusInWonderland.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HummusInWonderland.DAL.HummhusInWonderlandContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HummhusInWonderland.DAL.HummhusInWonderlandContext";
        }

        protected override void Seed(HummusInWonderland.DAL.HummhusInWonderlandContext context)
        {
            var menu = new List<Product>
            {
                new Product { ProductID = 1,   ProductName = "����� ���",
                    ProductDescription = "����� �� ��� ��� ����, ������, ���������, ��� ���, ����, ������, 2�����, ������",
                Price = 38, ProductImage = "/Images/hummus_meat_top.png"},
                new Product { ProductID = 2,   ProductName = "����� ������",
                    ProductDescription = "����� �� ������ �����, ������� �� ��� ��������. ���� �� ������, ���������, ��� ���, ����, ������, 2�����, ������",
                Price = 34, ProductImage = "/Images/hummus_mushroom_top.png"},
                new Product { ProductID = 3,   ProductName = "����� �����",
                    ProductDescription = "����� �� ����� ���� �����, ���� �� ������, ���������, ��� ���, ����, ������, 2�����, ������",
                Price = 34, ProductImage = "/Images/hummus_tznubar_top.png"},
                new Product { ProductID = 4,   ProductName = "�����",
                    ProductDescription = "����� �� ������, ���������, ��� ���, ����, ����, ������, 2�����, ������",
                Price = 25, ProductImage = "/Images/hummus_top.png"},
                new Product { ProductID = 5,   ProductName = "����� ���",
                    ProductDescription = "����� �� ��� ������, ���������, ��� ���, ����, ����, ������, , 2�����, ������",
                Price = 25,ProductImage = "/Images/hummus_ful_top.png"},
                new Product { ProductID = 6,   ProductName = "����� �������",
                    ProductDescription = "������� �� ����� ����� �� ������, ���������, ��� ���, ����, ����, ������, 2�����, ������",
                Price = 25,ProductImage = "/Images/mashausha_top.png"},
                new Product { ProductID = 7,   ProductName = "�������",
                    ProductDescription = "1/3����� 1/3������� 1/3���, ����� �� ������, ���������, ��� ���, ����, ����, ������, 2�����, ������",
                Price = 25,ProductImage = "/Images/hummus_tri_top.png"},
                new Product { ProductID = 8,   ProductName = "��� ���",
                    ProductDescription = "��� ��� �� �����, �����, ������, �����",
                Price = 25,ProductImage = "/Images/hummus_salad_front.png"},

            };
            menu.ForEach(m => context.Menu.AddOrUpdate(p => p.ProductID, m));
            context.SaveChanges();

            var customer = new List<Customer>
            {
                new Customer {CustomerID = 1, FirstName = "�����", LastName ="�������", BirthDate = DateTime.Parse("1994-08-13") ,
                Gender = Gender.���, Email = "halleldaniel@gmail.com", City ="��� ����", Street = "�����", Password ="1234", PhoneNumber = "0543034020"},
                new Customer {CustomerID = 2, FirstName = "����", LastName ="����", BirthDate = DateTime.Parse("1993-11-19") ,
                Gender = Gender.���, Email = "amit.harari93@gmail.com", City ="�� ����", Street = "��� ������", Password ="1234", PhoneNumber = "0528465750"},
                new Customer {CustomerID = 3, FirstName = "�����", LastName ="����������", BirthDate = DateTime.Parse("1994-03-11") ,
                Gender = Gender.����, Email = "alisa6450@gmail.com", City ="��� ���", Street = "�����", Password ="1234", PhoneNumber = "0543016142"},
                new Customer {CustomerID = 4, FirstName = "���", LastName ="����", BirthDate = DateTime.Parse("1980-09-17") ,
                Gender = Gender.���, Email = "shaharhason@gmail.com", City ="����", Street = "������", Password ="1234", PhoneNumber = "0507878787"},
                new Customer {CustomerID = 5, FirstName = "����", LastName ="����", BirthDate = DateTime.Parse("1983-04-12") ,
                Gender = Gender.���, Email = "adirmiller@gmail.com", City ="��� �����", Street = "�����", Password ="1234", PhoneNumber = "0526767489"},
                new Customer {CustomerID = 6, FirstName = "��", LastName ="�����", BirthDate = DateTime.Parse("1985-09-13"),
                Gender = Gender.����, Email = "barrefaeli@gmail.com", City ="�� ����", Street = "����������", Password ="1234", PhoneNumber = "0526839072"},
                new Customer {CustomerID = 7, FirstName = "��", LastName ="����", BirthDate = DateTime.Parse("1986-02-18") ,
                Gender = Gender.����, Email = "galgadot@gmail.com", City ="�� ����", Street = "����������", Password ="1234", PhoneNumber = "0508362973"}
            };
            customer.ForEach(c => context.Customers.AddOrUpdate(p => p.CustomerID, c));
            context.SaveChanges();


            var orders = new List<Order>
            {
                new Order { OrderID = 1, CustomerId = customer.Single(s => s.LastName == "�����").CustomerID, ProductID = menu.Single(s => s.ProductName == "�����").ProductID, OrderDate = DateTime.Parse("2016-02-14"), TotalPrice= 25},
                new Order { OrderID = 2, CustomerId = customer.Single(s => s.LastName == "�������").CustomerID, ProductID = menu.Single(s => s.ProductName == "����� ���").ProductID, OrderDate = DateTime.Parse("2016-03-14"), TotalPrice= 25},
                new Order { OrderID = 3, CustomerId = customer.Single(s => s.LastName == "�����").CustomerID, ProductID = menu.Single(s => s.ProductName == "����� ���").ProductID, OrderDate = DateTime.Parse("2016-04-14"), TotalPrice= 2},
                new Order { OrderID = 4, CustomerId = customer.Single(s => s.LastName == "����").CustomerID, ProductID = menu.Single(s => s.ProductName == "�������").ProductID, OrderDate = DateTime.Parse("2016-05-14"), TotalPrice= 38},
                new Order { OrderID = 5, CustomerId = customer.Single(s => s.LastName == "����������").CustomerID, ProductID = menu.Single(s => s.ProductName == "��� ���").ProductID, OrderDate = DateTime.Parse("2016-05-14"), TotalPrice= 34},
                new Order { OrderID = 6, CustomerId = customer.Single(s => s.LastName == "����").CustomerID, ProductID = menu.Single(s => s.ProductName == "����� �������").ProductID, OrderDate = DateTime.Parse("2016-06-14"), TotalPrice= 25},
                new Order { OrderID = 7, CustomerId = customer.Single(s => s.LastName == "����").CustomerID, ProductID = menu.Single(s => s.ProductName == "�����").ProductID, OrderDate = DateTime.Parse("2016-06-14"), TotalPrice= 34}

            };
            orders.ForEach(o => context.Orders.AddOrUpdate(p => p.OrderID, o));
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
            customer.ForEach(c => context.Customers.AddOrUpdate(p => p.CustomerID, c));
            context.SaveChanges();

            var branch = new List<Branch>
            {
                new Branch {BranchID = 1, BranchCity= "�� ����", BranchName = "����� ���", BranchsHouseNumber = 3,BranchsPhoneNumber = "03-4678953", BranchStreet = "��� ������" },
                new Branch {BranchID = 2, BranchCity= "�������", BranchName = "����� ���", BranchsHouseNumber = 12,BranchsPhoneNumber = "04-7895034", BranchStreet = "���� ����" },
                new Branch {BranchID = 3, BranchCity= "��� ���", BranchName = "����� ���", BranchsHouseNumber = 56,BranchsPhoneNumber = "08-6457890", BranchStreet = "����� �����" },
                new Branch {BranchID = 4, BranchCity= "����", BranchName = "����� ���", BranchsHouseNumber = 34,BranchsPhoneNumber = "09-8765942", BranchStreet = "�����" }
            };
            branch.ForEach(b => context.Branches.AddOrUpdate(p => p.BranchID, b));
            context.SaveChanges();
        }
    }
}

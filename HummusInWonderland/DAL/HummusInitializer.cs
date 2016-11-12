using System;
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
            var products = new List<Product>
            {
                new Product {ProductName="חומוס", Price=26, ProductDescription="חומוס טרי", ProductID=1, ProductImage="none"},
                new Product {ProductName="חומוס", Price=26, ProductDescription="חומוס טרי", ProductID=1, ProductImage="none"},
                new Product {ProductName="חומוס", Price=26, ProductDescription="חומוס טרי", ProductID=1, ProductImage="none"}
            };

            products.ForEach(p => context.Menu.Add(p));
            context.SaveChanges();
        }
    }
}
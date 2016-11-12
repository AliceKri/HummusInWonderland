namespace HummusInWonderland.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HummhusInWonderland.DAL.HummhusInWonderlandContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HummhusInWonderland.DAL.HummhusInWonderlandContext";
        }

        protected override void Seed(HummhusInWonderland.DAL.HummhusInWonderlandContext context)
        {
            var menu = new List<Menu>
            {
                new Menu { MenuID = 1,   ProductName = "����� ���",
                    ProductDescription = "����� �� ��� ��� ����, ������, ���������, ��� ���, ����, ������, 2�����, ������",
                ProductImage = "/Images/hummus_meat_top.png"},
                new Menu { MenuID = 2,   ProductName = "����� ������",
                    ProductDescription = "����� �� ������ �����, ������� �� ��� ��������. ���� �� ������, ���������, ��� ���, ����, ������, 2�����, ������",
                ProductImage = "/Images/hummus_mushroom_top.png"},
                new Menu { MenuID = 3,   ProductName = "����� �����",
                    ProductDescription = "����� �� ����� ���� �����, ���� �� ������, ���������, ��� ���, ����, ������, 2�����, ������",
                ProductImage = "/Images/hummus_tznubar_top.png"},
                new Menu { MenuID = 1,   ProductName = "����� ���",
                    ProductDescription = "����� �� ��� ��� ����, ������, ���������, ��� ���, ����, ������, 2�����, ������",
                ProductImage = "/Images/hummus_meat_top.png"},
                new Menu { MenuID = 1,   ProductName = "����� ���",
                    ProductDescription = "����� �� ��� ��� ����, ������, ���������, ��� ���, ����, ������, 2�����, ������",
                ProductImage = "/Images/hummus_meat_top.png"},
                new Menu { MenuID = 1,   ProductName = "����� ���",
                    ProductDescription = "����� �� ��� ��� ����, ������, ���������, ��� ���, ����, ������, 2�����, ������",
                ProductImage = "/Images/hummus_meat_top.png"},
                new Menu { MenuID = 1,   ProductName = "����� ���",
                    ProductDescription = "����� �� ��� ��� ����, ������, ���������, ��� ���, ����, ������, 2�����, ������",
                ProductImage = "/Images/hummus_meat_top.png"},
                new Menu { MenuID = 1,   ProductName = "����� ���",
                    ProductDescription = "����� �� ��� ��� ����, ������, ���������, ��� ���, ����, ������, 2�����, ������",
                ProductImage = "/Images/hummus_meat_top.png"},

            };
        }
    }
}

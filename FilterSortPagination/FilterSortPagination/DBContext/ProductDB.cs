using FilterSortPagination.Models;

namespace FilterSortPagination.DBContext
{
    public class ProductDB
    {
        public List<ProductModel> ProductDataContext { get; } = new List<ProductModel>()
        {
            new ProductModel(){Id=1,Name="Mouse",Description="Wireless Mouse",Price=300},
            new ProductModel(){Id=2,Name="Keyboard",Description="Wireless Kayboard",Price=500},
            new ProductModel(){Id=3,Name="Speaker",Description="JBL Speaker ",Price=200},
            new ProductModel(){Id=4,Name="CPU",Description="Server cpu ",Price=3000},
            new ProductModel(){Id=5,Name="HeadPhone",Description="JBL ",Price=550},
            new ProductModel(){Id=6,Name="Desktop",Description="LCD ",Price=30000},
            new ProductModel(){Id=7,Name="Desk Lamp",Description="With battery ",Price=208},
            new ProductModel(){Id=8,Name="Fan",Description="Table fan ",Price=609},
            new ProductModel(){Id=9,Name="Box",Description="File box ",Price=68},
            new ProductModel(){Id=10,Name="Books",Description="Library ",Price=458},
            new ProductModel(){Id=11,Name="Pen",Description="Pen holder ",Price=67},
            new ProductModel(){Id=12,Name="Phone",Description="Apple ",Price=648466},
            new ProductModel(){Id=13,Name="Ups",Description="Ups ",Price=693568},
            new ProductModel(){Id=14,Name="Disk",Description="Hard disk ",Price=685456},
        };
    }
}

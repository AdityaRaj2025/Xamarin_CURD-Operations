using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CURD_Example.Models
{
    public class ProductInfo
    {
        [PrimaryKey, AutoIncrement]
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int Description { get; set; }
        public int ImageUrl { get; set; }
    }
}

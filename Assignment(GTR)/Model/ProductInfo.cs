using System.Security.Claims;

namespace Assignment_GTR_.Model
{
    public class ProductInfo
    {
        internal object ? simple;

        public int Id { get; set; }
        public int ID { get; internal set; }
        public string ? CategoryName { get; set; }
        public string ? UniteName { get; set; }
        public string ? Name { get; set; }
        public int Code { get; set; }
        public int ProductBarcode { get; set; }
        public int ProductBarCode { get; set; }
        public string ? Description { get; set; }
        public string ? BrandName { get; set; }
        public string ? SizeName { get; set; }
        public string ? ColorName { get; set; }
        public string ? ModelName { get; set; }
        public string ? VarinName { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public string ? WarehouseList { get; set; }
        public decimal stock { get; set; }
        public decimal TotalPurchase { get; set; }
        public DateTime LastPurchaseDate { get; set; }
        public string ? LastPurchase { get; set; }
        public decimal TotalSales { get; set; }
        public DateTime LastSaleDate { get; set; }
        public string ? LastSalesCustomer { get; set; }
        public string ? ImagePath { get; set; }
        public string ? Type { get; set; }
        public string ? Status { get; set; }
        public object ? UnitName { get; internal set; }
        public object ? ParentCode { get; internal set; }
        public object ? VariantName { get; internal set; }
        public object ? LastPurchaseSupplier { get; internal set; }
        public object ? LastSalesDate { get; internal set; }
    }
}

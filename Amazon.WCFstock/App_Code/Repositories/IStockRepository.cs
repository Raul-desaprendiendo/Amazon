using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface IStockRepository
{
    List<ProductStock> GetAllStock();
    ProductStock GetProductStockById(int id);
    bool UpdateProductStock(ProductStock product);
}
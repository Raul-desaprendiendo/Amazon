using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    private IStockRepository _stockRepository;
    public Service()
    {
        _stockRepository = new StockRepository();
    }
    public List<ProductStock> GetAllStock()
    {
        return _stockRepository.GetAllStock();

    }

    public ProductStock GetProductStockById(int id)
    {
        if (!ProductExists(id))
        {
            return null;
        }
        return _stockRepository.GetProductStockById(id);
    }
    public bool ProductExists(int id)
    {
        return _stockRepository.GetProductStockById(id) != null;
    }

    public bool ReduceItemStock(int id, int cuantity)
    {
        ProductStock product = GetProductStockById(id);
        if (!ProductExists(id))
        {
            return false;
        }
        ProductStock newProduct = new ProductStock() { Id = id, Ammount = product.Ammount - cuantity };
        return UpdateProductStock(newProduct);
    }

    public bool UpdateProductStock(ProductStock product)
    {
        if (!ProductExists(product.Id))
        {
            return false;
        }
        return _stockRepository.UpdateProductStock(product);
    }
}

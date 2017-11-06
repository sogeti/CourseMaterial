using System;
using WebShop.DomainModel;
using WebShop.DataAccessLayer.DAOs;

namespace WebShop.BusinessLogicLayer.UseCases
{
    public class EditShoppingCart
    {
        IProductDAO _productDAO;

        public EditShoppingCart(IProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public Order AddProductToOrder(Order existingOrder, int productId, int quantity)
        {
            Product newProduct = _productDAO.SelectOne(productId);
            if (newProduct == null)
            {
                throw new ApplicationException("Product being ordered does not exist");
            }

            Order result;
            if (existingOrder == null)
            {
                result = new Order();
            }
            else
            {
                result = existingOrder;
            }

            OrderLine orderLine = new OrderLine(newProduct, quantity);
            if (orderLine.IsValid)
            {
                result.AddOrderLine(orderLine);
                return result;
            }
            throw new ApplicationException("Invalid order");
        }

        public Order RemoveOrderLineFromOrder(Order existingOrder, string productName)
        {
            existingOrder.RemoveOrderLine(productName);
            return existingOrder;            
        }

    }
}

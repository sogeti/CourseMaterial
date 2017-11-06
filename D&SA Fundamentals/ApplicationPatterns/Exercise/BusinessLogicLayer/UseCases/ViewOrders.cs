using System.Collections.Generic;
using WebShop.DataAccessLayer.DAOs;
using System.Collections.ObjectModel;
using WebShop.DomainModel;

namespace WebShop.BusinessLogicLayer.UseCases
{
    public class ViewOrders
    {
        IOrderDAO _orderDAO;

        public ViewOrders(IOrderDAO orderDAO)
        {;
            _orderDAO = orderDAO;
        }

        public ICollection<OrderLine> GetOrderLinesByOrderId(int OrderId)
        {
            //TODO: add linq expression            
            Order order = _orderDAO.SelectOne(OrderId);

            if (order != null)
            {
                if (order.Customer.Id == CurrentUser.CustomerId)
                {
                    //only if the customer that ordered the order is the same as the
                    //current customer we should return the orderlines
                    return order.OrderLines;
                }
            }            
            return new Collection<OrderLine>();
        }
    }
}

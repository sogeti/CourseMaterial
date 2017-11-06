using WebShop.DataAccessLayer.DAOs;
using WebShop.DomainModel;

namespace WebShop.BusinessLogicLayer.UseCases
{
    public class OrderProducts
    {
        ICustomerDAO _customerDAO;
        IOrderDAO _orderDAO;

        public OrderProducts(ICustomerDAO customerDAO, IOrderDAO orderDAO)
        {
            _customerDAO = customerDAO;
            _orderDAO = orderDAO;
        }

        public bool SaveOrder(Order order, string ipAddress)
        {
            order.IpAddress = ipAddress;
            Customer customer = _customerDAO.SelectOne(CurrentUser.CustomerId);
            if (customer == null)
            {
                return false;
            }
            order.Customer = customer;
            if (order.IsValid)
            {
                return _orderDAO.Insert(order);
            }
            else
            {
                return false;
            }
        }
    }
}

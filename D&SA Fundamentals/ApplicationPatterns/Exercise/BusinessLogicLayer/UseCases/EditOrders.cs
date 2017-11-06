using WebShop.DataAccessLayer.DAOs;
using WebShop.DomainModel;

namespace WebShop.BusinessLogicLayer.UseCases
{
    public class EditOrders
    {
        private IOrderDAO _orderDAO;

        public EditOrders(IOrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        public bool DeleteOrderById(Order order)
        {
            return _orderDAO.Delete(order);
        }
    }
}

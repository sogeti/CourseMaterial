using WebShop.DomainModel;

namespace WebShop.DataAccessLayer.DAOs
{
    public interface ICustomerDAO
    {
        Customer SelectOne(int customerId);
    }
}
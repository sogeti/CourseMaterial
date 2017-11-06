using WebShop.DomainModel;

namespace WebShop.DataAccessLayer.DAOs
{
    public interface IOrderDAO
    {
        bool Delete(Order businessObject);
        bool Insert(Order businessObject);
        Order SelectOne(int Id);
    }
}
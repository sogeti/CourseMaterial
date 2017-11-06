using WebShop.DomainModel;

namespace WebShop.DataAccessLayer.DAOs
{
    public interface IProductDAO
    {
        bool Insert(Comment comment, int productId);
        Product SelectOne(int Id);
        bool Update(Product businessObject);
    }
}
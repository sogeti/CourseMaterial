using System;
using WebShop.DomainModel;
using WebShop.DataAccessLayer.DAOs;

namespace WebShop.BusinessLogicLayer.UseCases
{
    public class EditProducts
    {
        ICustomerDAO _customerDAO;
        IProductDAO _productDAO;

        public EditProducts(ICustomerDAO customerDAO, IProductDAO productDAO)
        {
            _customerDAO = customerDAO;
            _productDAO = productDAO;
        }

        public bool UpdateProduct(string Name, string Description, decimal Price, Int32 Id)
        {
            Product p = new Product();
            p.Id = Id;
            p.Name = Name;
            p.Description = Description;
            p.Price = Price;
                        
            if (p.IsValid)
            {
                return _productDAO.Update(p);
            }
            else
            {
                return false;
            }
        }

        public bool InsertComment(string CommentText, int productId)
        {                       
            Customer customer = _customerDAO.SelectOne(CurrentUser.CustomerId);
            if (customer == null)
            {
                throw new ApplicationException("No such customer");
            }
            
            Comment c = new Comment();
            c.Customer = customer;
            c.CommentText = CommentText;

            if (c.IsValid)
            {
                _productDAO.Insert(c, productId);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

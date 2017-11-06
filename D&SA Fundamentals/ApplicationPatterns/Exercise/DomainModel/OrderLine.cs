using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebShop.DomainModel
{
    public class OrderLine : BusinessObject
    {
        public OrderLine() {}

        public OrderLine(Product product) : this(product, 1) {}        

        public OrderLine(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
             
        [Required(ErrorMessage="A quantity is required")]
        [Range(1, 1000, ErrorMessage="The quantity should be between 1 and 1000")]
        [DataMember(IsRequired = true)]
        public Int32 Quantity { get; set; }

        [Required()]
        [DataMember(IsRequired = true)]
        public Product Product { get; set; }

        public string ProductName
        {
            get
            {
                return Product.Name;
            }
        }

        public Int32 ProductId
        {
            get
            {
                return Product.Id;
            }
        }                
        
        public decimal TotalPrice
        {
            get
            {
                return Product.Price * Quantity;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace WebShop.DomainModel
{
    public class Order : BusinessObject
    {              
        public Order()
        {
            OrderLines = new List<OrderLine>();
        }
        
        [Required()]
        [IgnoreDataMember()]
        public Customer Customer { get; set; }
        
        [Required()]
        [DataMember(IsRequired=true)]
        public DateTime OrderDate { get; set; }

        [DataMember()]
        public List<OrderLine> OrderLines  { get; set; }

        [Required()]
        [RegularExpression(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b", ErrorMessage="Not valid IP address")]
        [IgnoreDataMember()]
        public string IpAddress { get; set;}        

        public int ProductsCount
        {
            get
            {
                if (OrderLines != null)
                {
                    return OrderLines.Count();
                }
                else
                {
                    return 0;
                }                
            }
        }
        
        private decimal? _totalPrice = null;
        public decimal TotalPrice
        {
            get
            {
                if (_totalPrice.HasValue)
                {
                    //total price of the order is stored in the database
                    //and is not necessarily equal to the current product pricing       
                    return _totalPrice.Value;
                }
                else
                {
                    decimal result = 0;

                    if (OrderLines != null && OrderLines.Count() != 0)
                    {
                        foreach (OrderLine line in this.OrderLines)
                        {
                            result += line.TotalPrice;
                        }
                    }
                    return result;
                }
            }
            set 
            {
                _totalPrice = value;
            }
        }
        
        public void AddOrderLine(OrderLine orderLine)
        {
            //first check if the orderline already exists
            foreach (OrderLine currentOrderline in OrderLines)
            {
                if (currentOrderline.Product == orderLine.Product)
                {
                    currentOrderline.Quantity += orderLine.Quantity;
                    return;
                }
            }
            //if no existing orderline matched just add the new orderline
            OrderLines.Add(orderLine);
            return;            
        }
        
        public void RemoveOrderLine(string productName)
        {
            OrderLines = (from o in OrderLines where o.ProductName != productName select o).ToList();
        }
    }
}

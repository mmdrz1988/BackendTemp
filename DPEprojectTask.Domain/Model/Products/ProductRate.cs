using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Model.Products
{
    public class ProductRate
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public byte Rate { get; set; }

        public ProductRate(int id, int productId, int userId, byte rate)
        {
            Id = id;
            ProductId = productId;
            UserId = userId;
            Rate = rate;
        }
    }
}

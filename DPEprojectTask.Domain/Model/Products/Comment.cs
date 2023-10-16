using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Model.Products
{
    public class Comment
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsVerified { get; set; }
        public int? ParentId { get; set; }

        public Comment()
        {
        }

        public Comment(int id, int productId, int userId, string body, DateTime createdDate, bool isVerified, int? parentId)
        : this()
        {
            Id = id;
            ProductId = productId;
            UserId = userId;
            Body = body;
            CreatedDate = createdDate;
            IsVerified = isVerified;
            ParentId = parentId;
        }
    }
}

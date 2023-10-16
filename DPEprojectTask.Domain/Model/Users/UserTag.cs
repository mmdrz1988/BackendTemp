using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Model.Users
{
    public class UserTag
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TagId { get; set; }

        public UserTag(int id, int userId, int tagId)
        {
            Id = id;
            UserId = userId;
            TagId = tagId;
        }
    }
}

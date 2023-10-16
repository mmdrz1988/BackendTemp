using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Model.Tags
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Tag(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

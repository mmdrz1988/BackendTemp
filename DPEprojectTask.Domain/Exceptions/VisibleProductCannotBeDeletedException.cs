using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Exceptions
{
    public class VisibleProductCannotBeDeletedException : ExceptionBase
    {
        public VisibleProductCannotBeDeletedException(string msg) : base(msg)
        {
        }
    }
}

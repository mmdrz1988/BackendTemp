using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Exceptions
{
    public class UpdatedPriceCanNotBeMoreThanTenPercentException : ExceptionBase
    {
        public UpdatedPriceCanNotBeMoreThanTenPercentException(string msg) : base(msg)
        {
        }
    }
}

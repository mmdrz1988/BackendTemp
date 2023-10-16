using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPETasks.Core.Common.Contracts
{
    public interface IProductImageService
    {
        Task<string> SaveImageAsync(IFormFile file);
    }
}

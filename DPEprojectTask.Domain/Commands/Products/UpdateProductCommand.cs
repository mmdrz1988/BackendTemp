﻿using DPEprojectTask.Domain.CommandsResults.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Commands.Products
{
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string FilePath { get; set; }
        public short ProductCategoryId { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSellable { get; set; }
    }
}

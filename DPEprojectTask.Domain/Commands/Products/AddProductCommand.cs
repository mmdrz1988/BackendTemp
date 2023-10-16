using DPEprojectTask.Domain.CommandsResults.Products;
using MediatR;

namespace DPEprojectTask.Domain.Commands.Products
{
    public class AddProductCommand : IRequest<AddProductResult>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string FilePath { get; set; }
        public short ProductCategoryId { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSellable { get; set; }

        public AddProductCommand()
        {
        }

        public AddProductCommand(AddProductCommand model)
        {
            Title = model.Title;
            Body = model.Body;
            Price = model.Price;
            ImagePath = model.ImagePath;
            FilePath = model.FilePath;
            ProductCategoryId = model.ProductCategoryId;
            IsVisible = model.IsVisible;
            IsDeleted = model.IsDeleted;
            IsSellable = model.IsSellable;
        }
    }
}

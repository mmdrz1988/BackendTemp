using DPEprojectTask.Domain.Commands.Products;
using DPEprojectTask.Domain.Exceptions;

namespace DPEprojectTask.Domain.Model.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string FilePath { get; set; }
        public short ProductCategoryId { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSellable { get; set; }

        public List<Comment> _comments;
        public IReadOnlyCollection<Comment> comments => _comments;
        public List<ProductRate> _productRate;
        public IReadOnlyCollection<ProductRate> ProductRates => _productRate;
        public List<ProductTag> _productTag;

        public IReadOnlyCollection<ProductTag> ProductTagss => _productTag;

        public Product()
        {
            _comments = new List<Comment>();
            _productRate = new List<ProductRate>();
            _productTag = new List<ProductTag>();
        }

        public Product(int id, string title, string body, DateTime createdAt, decimal price, string imagePath, string filePath, short productCategoryId, bool isVisible, bool isDeleted, bool isSellable)
        : this()
        {
            Id = id;
            Title = title;
            Body = body;
            CreatedAt = createdAt;
            Price = price;
            ImagePath = imagePath;
            FilePath = filePath;
            ProductCategoryId = productCategoryId;
            IsVisible = isVisible;
            IsDeleted = isDeleted;
            IsSellable = isSellable;
        }

        public void update(UpdateProductCommand UPC)
        {
            var Increase = UPC.Price - Price;
            var Percentage = Increase/Price * 100;
            if (Percentage > 10)
                throw new UpdatedPriceCanNotBeMoreThanTenPercentException($"Old Value is {Price} and new Value is {UPC.Price}");

            Id = UPC.Id;
            Title = UPC.Title;
            Body = UPC.Body;
            Price = UPC.Price;
            ImagePath = UPC.ImagePath;
            FilePath = UPC.FilePath;
            ProductCategoryId = UPC.ProductCategoryId;
            IsVisible = UPC.IsVisible;
            IsDeleted = UPC.IsDeleted;
            IsSellable = UPC.IsSellable;
        }

        public void Delete()
        {
            if (IsVisible)
                throw new VisibleProductCannotBeDeletedException($"visible product can not be deleted.product id is {Id}");

            IsDeleted = true;
        }
    }
}

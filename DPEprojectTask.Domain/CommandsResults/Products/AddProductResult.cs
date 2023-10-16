namespace DPEprojectTask.Domain.CommandsResults.Products
{
    public class AddProductResult
    {
        public int Id { get; set; }
        public AddProductResult( int ProductId)
        {
            Id = ProductId;
        }
    }
}

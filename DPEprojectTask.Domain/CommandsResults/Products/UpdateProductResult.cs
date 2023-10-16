namespace DPEprojectTask.Domain.CommandsResults.Products
{
    public class UpdateProductResult
    {
        public int id { get; set; }

        public UpdateProductResult(int id)
        {
            this.id = id;
        }
    }
}

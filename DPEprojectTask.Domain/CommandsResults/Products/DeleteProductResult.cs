namespace DPEprojectTask.Domain.CommandsResults.Products
{
    public class DeleteProductResult
    {
        public int id { get; set; }

        public DeleteProductResult(int id)
        {
            this.id = id;
        }
    }
}

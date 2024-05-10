namespace AuthenticationApplication.Models
{
    public class DBConfiguration
    {
        public string MongodbConnectionstring { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ProductsCollectionName { get; set; } = null!;
    }
}

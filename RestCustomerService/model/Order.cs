namespace RestCustomerService.model
{
    public class Order
    {
        public static int NextId = 2;

        public int Id { get; set; }
        public int CustomerId { get; set; }
        // TODO Only 1 item pr order for now
        public string Item { get; set; }
        public double Price { get; set; }
    }
}

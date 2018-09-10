namespace RestCustomerService.model
{
    public class Customer
    {
        public static int NextId = 2;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }

        /*public Customer()
        {
            
        }*/

        /*public Customer(int id, string first, string last, int year)
        {

        }*/
    }
}

namespace BaltaStore.Domain.StoreContext.CustomerCommands.inputs
{
    public class CreatedCustomerCommand 
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string phone  { get; set; }
    }
}
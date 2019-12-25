namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name 
    {
        public Name(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
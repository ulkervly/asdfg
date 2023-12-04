namespace PustokPractice.CustomExceptions.Book
{
    public class TotalBookException:Exception
    {
        public string PropertyName { get; set; }
        public TotalBookException()
        {
        }

        public TotalBookException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}

namespace TourAPI.Common.UserDefinedExceptions
{
    public class CustomerSqlException : Exception
    {
        string _name;
        public CustomerSqlException() { 
            _name= string.Empty;
        }
        public CustomerSqlException(string name)
        {
            _name = name;
        }
        public override string Message => $"Could not add customer {_name} to the table ";
    }
}

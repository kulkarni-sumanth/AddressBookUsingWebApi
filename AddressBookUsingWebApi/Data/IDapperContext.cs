using System.Data;

namespace AddressBookUsingWebApi.Data
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}
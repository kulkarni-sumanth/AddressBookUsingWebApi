using AddressBookUsingWebApi.Data;
using AddressBookUsingWebApi.Models;
using Dapper;

namespace AddressBookUsingWebApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IDapperContext Context { get; set; }
        public EmployeeRepository(IDapperContext context)
        {
            this.Context = context;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            string query = "Insert into Employees values(@Name,@Email,@MobileNumber,@LandlineNumber,@Website,@Address)";
            string queryToRetriveRecord = "Select Top 1 * from Employees Order by Id desc";
            using(var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query,employee);
                var record = await connection.QuerySingleOrDefaultAsync<Employee>(queryToRetriveRecord);
                return record;
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            string query = "Delete from Employees where Id=@id";
            using(var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
        public async Task EditEmployeeAsync(Employee employee)
        {
            string query = "Update Employees Set Name=@Name, Email=@Email, MobileNumber=@MobileNumber, LandlineNumber=@LandlineNumber, Website=@Website, Address=@Address where Id=@Id;";
            using (var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, employee);
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            string query = "select * from Employees";
            using (var connection = Context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            string query = "Select * from Employees where Id = @id";
            using (var connection = Context.CreateConnection())
            {
                Employee employee = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { id });
                return employee;
            }
        }
    }
}
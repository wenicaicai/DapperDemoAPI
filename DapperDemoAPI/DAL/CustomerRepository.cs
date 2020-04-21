using Dapper;
using DapperDemoAPI.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperDemoAPI.DAL
{


    public class CustomerRepository : ICustomerRepository
    {

        private IDbConnection _db;

        public CustomerRepository(string connectString)
        {
            _db = new SqlConnection(connectString);
        }

        //LIST
        public IEnumerable<Customer> GetCustomers(int amount, string sort)
        {
            return this._db.Query<Customer>(@"SELECT TOP "+amount+ " [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM Customer ORDER BY CustomerID " + sort).ToList();
        }

        //READ
        public Customer GetSingleCustomer(int customerId)
        {
            return this._db.Query<Customer>(@"SELECT [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM Customer WHERE CustomerID=@customerId", new { CustomerID = customerId }).SingleOrDefault();
        }

        //CREATE
        public bool InsertCustomer(Customer ourCustomer)
        {
            int rowAffected = this._db.Execute(@"INSERT INTO Customer([CustomerFirstName],[CustomerLastName],[IsActive]) VALUES(@CustomerFirstName, @CustomerLastName, @IsActive)",
                new { ourCustomer.CustomerFirstName, ourCustomer.CustomerLastName, IsActive = true });
            if (rowAffected > 0)
                return true;
            return false;
        }

        //DELETE
        public bool DeleteCustomer(int customerId)
        {
            int rowAffected = this._db.Execute(@"DELETE FROM [Customer] WHERE CustomerID=@CustomerID", new { CustomerID = customerId });
            if (rowAffected > 0)
                return true;
            return false;
        }

        //UPDATE
        public bool UpdateCustomer(Customer ourCustomer)
        {
            int rowAffected = this._db.Execute(@"UPDATE [Customer] SET [CustomerFirstName]=@CustomerFirstName,
		[CustomerLastName]=@[CustomerLastName],[IsActive]=@[IsActive] WHERE CustomerID=" + ourCustomer.CustomerID, ourCustomer);
            if (rowAffected > 0)
                return true;
            return false;
        }

        public PotentialCustomer MapCustomer(Customer customers)
        {
            var imapper = AutoMapperConfig.GetMapper();
            var result = imapper.Map<PotentialCustomer>(customers);
            return result;
        }

        public UniversityStu MapCustomer(Student student)
        {
            var imapper = AutoMapperConfig.GetMapper();
            var result = imapper.Map<UniversityStu>(student);
            return result;
        }


    }
}

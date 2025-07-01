using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data;

public class CustomerData : ICustomerData
{
    private readonly IDataAccess dataAccess;
    private readonly ConnectionStringData connectionString;

    public CustomerData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        this.dataAccess = dataAccess;
        this.connectionString = connectionString;
    }

    public async Task<int> CreateCustomer(CustomerModel customer)
    {
        DynamicParameters p = new();
        p.Add("Name", customer.Name);
        p.Add("Surname", customer.Surname);
        p.Add("Email", customer.Email);
        p.Add("Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

        await dataAccess.SaveData("dbo.spCustomer_Insert", p, connectionString.SqlConnectionName);
        return p.Get<int>("Id");
    }

    //could be done to update separate fields
    public Task<int> UpdateCustomer(CustomerModel customer)
    {
        DynamicParameters p = new();
        p.Add("Id", customer.Id);
        p.Add("Name", customer.Name);
        p.Add("Surname", customer.Surname);
        p.Add("Email", customer.Email);

        return dataAccess.SaveData("dbo.spCustomer_Update", p, connectionString.SqlConnectionName);
    }

    public Task<int> DeleteCustomer(int customerId)
    {
        return dataAccess.SaveData("dbo.spCustomer_Delete",
                                   new { Id = customerId },
                                   connectionString.SqlConnectionName);
    }

    public async Task<List<CustomerModel>> GetCustomers()
    {
        return await dataAccess.LoadData<CustomerModel, dynamic>("dbo.spCustomer_All",
                                                                 new { },
                                                                 connectionString.SqlConnectionName);
    }

    public async Task<CustomerModel> GetCustomerById(int customerId)
    {
        var results = await dataAccess.LoadData<CustomerModel, dynamic>("dbo.spCustomer_GetById",
                                                                        new { Id = customerId },
                                                                        connectionString.SqlConnectionName);
        return results.FirstOrDefault();
    }
}

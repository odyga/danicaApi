using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface ICustomerData
    {
        Task<int> CreateCustomer(CustomerModel customer);
        Task<int> DeleteCustomer(int customerId);
        Task<CustomerModel> GetCustomerById(int customerId);
        Task<List<CustomerModel>> GetCustomers();
        Task<int> UpdateCustomer(CustomerModel customer);
    }
}
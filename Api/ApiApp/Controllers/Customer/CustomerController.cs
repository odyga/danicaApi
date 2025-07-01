using ApiApp.Models;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiApp.Controllers.Customer;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerData customerData;

    public CustomerController(ICustomerData customerData)
    {
        this.customerData = customerData;
    }

    [HttpPost]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CustomerModel customer)
    {
        var id = await customerData.CreateCustomer(customer);

        return Ok(new { Id = id });
    }


    [HttpGet]
    public async Task<List<CustomerModel>> Get()
    {
        return await customerData.GetCustomers();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var customer = await customerData.GetCustomerById(id);

        return customer == null ? NotFound() : Ok(customer);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] CustomerUpdateModel data)
    {
        await customerData.UpdateCustomer(new CustomerModel
        {
            Id = data.Id,
            Name = data.Name,
            Surname = data.Surname,
            Email = data.Email
        });

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        await customerData.DeleteCustomer(id);

        return Ok();
    }
}

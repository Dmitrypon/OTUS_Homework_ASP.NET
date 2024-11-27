using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using AutoMapper;
using PromoCodeFactory.WebHost.Models.Requests;
using PromoCodeFactory.WebHost.Models.Responses;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController(ICustomerRepository customerRepository, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Получить данные всех покупателей
        /// Get the data of all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerShortResponse>), 200)]
        public async Task<IEnumerable<CustomerShortResponse>> GetAll() =>
            (await customerRepository.GetAllAsync()).Select(mapper.Map<CustomerShortResponse>);
        /// <summary>
        /// Получить данные покупателя по Id
        /// Get customer data by id
        /// </summary>        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CustomerResponse>> Get(Guid id)
        {
            var customer = await customerRepository.GetByIdAsync(id);
            if (customer == null) return NotFound();
            else return Ok(mapper.Map<CustomerResponse>(customer));
        }
        /// <summary>
        /// Добавить нового покупателя, с предпочтениями
        /// Add a new customer, with preferences
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerResponse), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CustomerResponse>> CreateCustomerAsynce([FromBody] CreateOrEditCustomerRequest request)
        {
            if (request.PreferenceIds.Count() == 0) return BadRequest("To get coupoins, you need to have at least one preferences");
            else
            {
                var response = await customerRepository.CreateAsync(mapper.Map<Customer>(request));
                return CreatedAtAction(nameof(Get), new { id = response.Id }, mapper.Map<CustomerResponse>(response));
            }
        }
        /// <summary>
        /// Обновить данные покупателя
        /// Update customer details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EditCustomerAsync(Guid id, [FromBody] CreateOrEditCustomerRequest request)
        {
            if ((await customerRepository.GetByIdAsync(id)) == null) return NotFound("Customer id not found");
            else if (request.PreferenceIds.Count() == 0) return BadRequest("To get coupons, you need to have at least one preference");
            else
            {
                await customerRepository.UpdateAsync(id, mapper.Map<Customer>(request));
                return NoContent();
            }
        }
        /// <summary>
        /// Удалить покупателя по Id, вместе с его уникальными промокодами
        /// Delete a customer by id, along with their unique promo codes
        /// </summary>
        /// <param name="id"></param>        
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            if ((await customerRepository?.GetByIdAsync(id)) == null) return NotFound("Customer id not found");
            else
            {
                await customerRepository.DeleteAsync(id);
                return NoContent();
            }
        }


    }
}
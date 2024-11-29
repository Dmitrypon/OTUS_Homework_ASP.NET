using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.Responses;
using PromoCodeFactory.WebHost.Models.Requests;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Промокоды
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromocodesController(IRepository<PromoCode, Guid> promoCodeRepository, 
        IRepository<Employee, Guid> employeeRepository,
        IRepository<Preference, Guid> preferenceRepository,
        ICustomerRepository customerRepository,
        IMapper mapper) : ControllerBase
    {         
        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PromoCodeShortResponse>), 200)]
        public async Task<IEnumerable<PromoCodeShortResponse>> GetPromoCodesAsync() =>
            (await promoCodeRepository.GetAllAsync()).Select(mapper.Map<PromoCodeShortResponse>);


        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// Create a promo code and issue it to customers with the specified preference
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GivePromoCodesToCustomersWithPreferencesAsync([FromBody] GivePromoCodeRequest request)
        {
            var customer = mapper.Map<CustomerResponse>(await customerRepository.GetByIdAsync(request.CustomerId));
            var preference = await preferenceRepository.GetByIdAsync(request.PreferenceId);
            if (customer == null) return NotFound("The customer with this id was not found");
            if ((await employeeRepository.GetByIdAsync(request.EmployeeId)) == null) return NotFound("The employee with this id was not found");
            if (preference == null) return NotFound("The preference with this id was not found");
            //Проверка наличия предпочтений
            if (customer.Preferences.Where(p => p.Name == preference.Name).FirstOrDefault() == null)
                return BadRequest("The customer does not have such preferences");

            var promoCode = mapper.Map<PromoCode>(request);
            promoCode.BeginDate = DateTime.Now.AddDays(request.BeforeStarts);
            promoCode.EndDate = promoCode.BeginDate.AddDays(request.HowLongDay);
            await promoCodeRepository.CreateAsync(promoCode);
            return NoContent();
        }
            
        
    }
}
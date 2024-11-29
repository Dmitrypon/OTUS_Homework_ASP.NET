using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.Responses;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Предпочтения клиентов
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PreferencesController(IRepository<Preference, Guid> preferenceRepository, IMapper mapper)
        : ControllerBase
    {
        /// <summary>
        /// Получить все предпочтения покупателей
        /// Get all customer preferences
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PreferenceResponse>), 200)]
        public async Task<IEnumerable<PreferenceResponse>> GetPreferencesAsync() =>
            (await preferenceRepository.GetAllAsync()).Select(mapper.Map<PreferenceResponse>);
        
    }
}
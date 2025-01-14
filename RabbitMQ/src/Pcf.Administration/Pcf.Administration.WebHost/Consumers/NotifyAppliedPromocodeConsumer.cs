using MassTransit;
using Microsoft.Extensions.Logging;
using Pcf.Administration.Core.Abstractions.Repositories;
using Pcf.Administration.Core.Domain.Administration; 
using Pcf.Contracts;
using System.Threading.Tasks;

namespace Pcf.Administration.WebHost.Consumers
{
    public class NotifyAppliedPromocodeConsumer(
        IRepository<Employee> employeeRepository
        , ILogger<NotifyAppliedPromocodeConsumer> logger) : IConsumer<PromoCodeMessageDTO>
    {
        async Task IConsumer<PromoCodeMessageDTO>.Consume(ConsumeContext<PromoCodeMessageDTO> context)
        {
            var uid = context.Message.Id;
            var employee = await employeeRepository.GetByIdAsync(uid);

            if (employee == null)
            {
                logger.LogInformation($"User by guid = {uid} not found");
                return;
            }

            employee.AppliedPromocodesCount++;

            await employeeRepository.UpdateAsync(employee);
        }
    }
}

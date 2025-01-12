﻿using MassTransit;
using Microsoft.Extensions.Logging;
using Pcf.Administration.Core.Abstractions.Repositories;
using Pcf.Administration.Core.Domain.Administration;
using Pcf.Administration.WebHost.Contracts;
using Pcf.Administration.WebHost.Models;
using Pcf.Administration.WebHost.Contracts;
using Pcf.Contracts;
using System.Threading.Tasks;

namespace Pcf.Administration.WebHost.Consumers
{
    public class NotifyAppliedPromocodeConsumer(
        IRepository<Employee> employeeRepository
        , ILogger<NotifyAppliedPromocodeConsumer> logger) : IConsumer<MessageDTO>
    {
        async Task IConsumer<MessageDTO>.Consume(ConsumeContext<MessageDTO> context)
        {
            var uid = context.Message.Uid;
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

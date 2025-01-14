using MassTransit;
using Microsoft.Extensions.Logging;
using Pcf.Administration.Core.Abstractions.Repositories;
using Pcf.Administration.Core.Domain.Administration;
using Pcf.Administration.WebHost.Contracts;
using Pcf.Contracts;
using System;
using System.Threading.Tasks;


namespace Pcf.Administration.WebHost.Contracts;

public class PromoCodeMessageDTO
{
    public Guid Id { get; set; }

    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid PartnerId { get; set; }

    public Guid? PartnerManagerId { get; set; }

    public Guid PreferenceId { get; set; }
}


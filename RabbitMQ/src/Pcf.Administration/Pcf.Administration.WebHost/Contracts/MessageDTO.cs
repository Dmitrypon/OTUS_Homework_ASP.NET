using MassTransit;
using Microsoft.Extensions.Logging;
using Pcf.Administration.Core.Abstractions.Repositories;
using Pcf.Administration.Core.Domain.Administration;
using Pcf.Administration.WebHost.Contracts;
using Pcf.Contracts;
using System.Threading.Tasks;


namespace Pcf.Administration.WebHost.Contracts;

public class MessageDTO
{	
         public Guid Uid { get; set; }
}


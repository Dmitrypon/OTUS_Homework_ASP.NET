using System;
using System.Net.Http;
using System.Threading.Tasks;
using Pcf.ReceivingFromPartner.Core.Abstractions.Gateways;
using MassTransit;
using Pcf.Contracts;

namespace Pcf.ReceivingFromPartner.Integration
{
    public class AdministrationGateway
      : IAdministrationGateway
    {
        private readonly IBusControl _busControl;

        public AdministrationGateway(
            IBusControl busControl
            )
        {
            _busControl = busControl;
        }

        public async Task NotifyAdminAboutPartnerManagerPromoCode(Guid partnerManagerId)
        {
            await _busControl.Publish(new PromoCodeMessageDTO { Id = partnerManagerId });
        }
    }
    //public class AdministrationGateway
    //    : IAdministrationGateway
    //{
    //    private readonly HttpClient _httpClient;

    //    public AdministrationGateway(HttpClient httpClient)
    //    {
    //        _httpClient = httpClient;
    //    }

    //    public async Task NotifyAdminAboutPartnerManagerPromoCode(Guid partnerManagerId)
    //    {
    //        var response = await _httpClient.PostAsync($"api/v1/employees/{partnerManagerId}/appliedPromocodes",
    //            new StringContent(string.Empty));

    //        response.EnsureSuccessStatusCode();
    //    }
    //}
}
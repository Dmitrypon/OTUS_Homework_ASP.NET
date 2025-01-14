using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.Contracts
{
    public class PromoCodeMessageDTO
    {
        public Guid Id { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid PartnerId { get; set; }

        public Guid? PartnerManagerId { get; set; }

        public Guid PreferenceId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductCampaign:IEntity
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int ProductId { get; set; }
        public double CampaignPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductCampaignDto:IEntity
    {
        public int CampaignId { get; set; }
        public List<int> ProductIdList { get; set; }
        public Dictionary<int,double> CampaignPrice { get; set; }

    }
}

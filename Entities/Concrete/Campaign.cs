using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities
{
    public class Campaign:IEntity
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
    }
}

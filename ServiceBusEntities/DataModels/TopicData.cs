using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataModels
{
    public class TopicData
    {
        public string TopicConnectionString { get; set; }
        public string topic { get; set; }
        public Subscriptions subscription { get; set; }
    }
}

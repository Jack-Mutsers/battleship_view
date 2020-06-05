using Entities.DataModels;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class SessionResponse
    {
        public Player Player { get; set; }
        public TopicData topicData { get; set; }
        public bool accepted { get; set; } // status if you got in
    }
}

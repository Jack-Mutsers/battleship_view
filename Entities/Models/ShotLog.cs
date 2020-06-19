using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ShotLog
    {
        public ICoordinate coordinate { get; set; }
        public bool hit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace TransportManager.DataAccess.Models
{
    public class Bus : DomainObject
    {
        public string Number { get; set; }
        public DateTime InspectionDate { get; set; }
        public bool IsHaveWheelChair { get; set; }
        public int Capacity { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Route Route { get; set; }
    }
}

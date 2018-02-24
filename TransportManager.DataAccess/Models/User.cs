using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;
using TransportManager.DataAccess.Enums;

namespace TransportManager.DataAccess.Models
{
    public class User : FullNamedDomainObject
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime LastVisit { get; set; }
    }
}

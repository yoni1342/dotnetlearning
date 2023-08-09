using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresDb.Models
{
    public class DriverMedia : BaseEntity
    {  
        public int DriverId { get; set; }
        public string Media { get; set; } = "";

        public virtual Driver Driver { get; set; }
    }
}
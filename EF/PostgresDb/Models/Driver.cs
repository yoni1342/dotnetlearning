using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresDb.Models
{
    public class Driver : BaseEntity
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = "";
        public int RacingNumber { get; set; } = 0;

        public virtual Team Team { get; set; }
        public virtual DriverMedia DriverMedia { get; set; }
    }
}
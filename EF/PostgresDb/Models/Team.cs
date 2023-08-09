using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresDb.Models
{
    public class Team : BaseEntity
    {
        public Team()
        {
            Drivers = new HashSet<Driver>();
        }
        public string Name { get; set; } = "";
        public int Year { get; set; } = 2022;

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
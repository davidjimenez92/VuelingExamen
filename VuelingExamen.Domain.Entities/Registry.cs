using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExamen.Domain.Entities
{
    public class Registry
    {
        public string Rebeld { get; set; }
        public string Planet { get; set; }
        public DateTime RegisterDate { get; set; }

        public override string ToString()
        {
            return $"Rebeld {Rebeld} on {Planet} at {RegisterDate}";
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            if (obj != null && GetType() == obj.GetType())
            {
                Registry registry = (Registry)obj;
                if ((this.Rebeld == registry.Rebeld) && (this.Planet == registry.Planet) && (this.RegisterDate == registry.RegisterDate))
                {
                    equals = true;
                }
            }

            return equals;
        }

        public override int GetHashCode()
        {
            return Rebeld.GetHashCode() ^ Planet.GetHashCode() ^ RegisterDate.GetHashCode();
        }
    }
}

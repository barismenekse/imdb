using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class DtoCastCastRole
    {
        public string movieName { get; set; }
        public string movieLink { get; set; }
        public string castName { get; set; }
        public string castRol { get; set; }
        public string castBio { get; set; }

        public string castLink { get; set; }

        public override string ToString()
        {
            return this.castName + " " + this.castRol;
        }
    }
}

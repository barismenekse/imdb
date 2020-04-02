using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Cast
    {
        public int CastId { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string bio { get; set; }

        public override string ToString()
        {
            return this.name + " " + this.link;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Movie
    {
        public override string ToString()
        {
            return "Adı : " + name + " Yılı : " + year + " Linki : " + link;
        }
        public int MovieId { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string year { get; set; }
        public string description { get; set; }

    }
}

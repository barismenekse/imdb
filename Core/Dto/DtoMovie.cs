using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class DtoMovie
    {
        public override string ToString()
        {
            return "Adı : " + name + " Yılı : " + year + " Linki : " + link;
        }
        public string name { get; set; }
        public string link { get; set; }
        public string year { get; set; }
        public string description { get; set; }
        public string rate { get; set; }

        public Boolean isSaved { get; set; }

    }
}

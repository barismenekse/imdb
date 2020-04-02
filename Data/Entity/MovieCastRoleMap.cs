using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class MovieCastRoleMap
    {
        [ForeignKey("MovieId")]
        public virtual Movie movie { get; set; }
        [Key]
        [Column(Order = 0)]
        public int MovieId { get; set; }

        [ForeignKey("CastId")]
        public virtual Cast cast { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CastId { get; set; }

        [ForeignKey("CastRoleId")]
        public virtual CastRole CastRole { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CastRoleId { get; set; }
    }
}

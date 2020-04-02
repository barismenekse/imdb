using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ImdbContext:DbContext
    {
        public ImdbContext():base("Context")
        {
            
        }
        public virtual DbSet<Cast> casts { get; set; }
        public virtual DbSet<CastRole> castRoles { get; set; }
        public virtual DbSet<Movie> movies { get; set; }
        public virtual DbSet<MovieCastRoleMap> MovieCastRoleMaps { get; set; }


    }
}

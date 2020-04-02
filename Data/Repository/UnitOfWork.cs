using Data.Context;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    
    public class UnitOfWork : IDisposable
    {
        
        private ImdbContext context = new ImdbContext();
        private Repository<Movie> movieRepo;
        private Repository<Cast> castRepo;
        private Repository<CastRole> castRoleRepo;
        private Repository<MovieCastRoleMap> movieCastRoleMapRepo;

        public Repository<Movie> MovieRepository
        {
            get
            {
                if (this.movieRepo == null)
                {
                    this.movieRepo = new Repository<Movie>(context);
                }
                return movieRepo;
            }
        }
        public Repository<Cast> CastRepository
        {
            get
            {
                if (this.castRepo == null)
                {
                    this.castRepo = new Repository<Cast>(context);
                }
                return castRepo;
            }
        }
        public Repository<CastRole> CastRoleRepository
        {
            get
            {
                if (this.castRoleRepo == null)
                {
                    this.castRoleRepo = new Repository<CastRole>(context);
                }
                return castRoleRepo;
            }
        }
        public Repository<MovieCastRoleMap> MovieCastRoleMapRepository
        {
            get
            {
                if (this.movieCastRoleMapRepo == null)
                {
                    this.movieCastRoleMapRepo = new Repository<MovieCastRoleMap>(context);
                }
                return movieCastRoleMapRepo;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
           
        }
    }
}

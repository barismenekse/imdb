using Data.Context;
using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repository
{
  
    public class Repository<T> : IRepository<T> where T : class
    {
        public delegate void SilmeDelegate(T obj);
        public event SilmeDelegate SilmeEvent;

        private ImdbContext _context;
        protected DbSet<T> table;
        
        public Repository(ImdbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
       /* public Repository(Context _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        */
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);

        }
       
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
           
        }
  
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            if (SilmeEvent != null) SilmeEvent(existing);
           
        }
     

        public T Select(Expression<Func<T, bool>> predicate)
        {
            T obj = table.Where(predicate).FirstOrDefault();
            return obj;

        }
        public List<T> SelectAll(Expression<Func<T, bool>> predicate)
        {
            List<T> obj = table.Where(predicate).ToList();
            return obj;
        }


        /*  public List<DtoCastCastRole> getCastList(Movie movie)
        {
            return (from c in _context.casts
                    join mcr in _context.MovieCastRoleMaps on c.CastId equals mcr.CastId
                    join m in _context.movies on mcr.MovieId equals m.MovieId
                    join cr in _context.castRoles on mcr.CastRoleId equals cr.CastRoleId
                    where movie.MovieId == m.MovieId
                    select new DtoCastCastRole { Name = c.name, Rol = cr.name, Bio = c.bio, castRolId = cr.CastRoleId, Link = c.link }).ToList();
        }*/
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;
using Qian.Shop.Core;
using IDAL;

namespace DAL
{
    public class DALService<T>:IDALService<T> where T : class, new()
    {
        private QianContext _context;

        public DALService(QianContext context)
        {
            _context = context;
        }

        public IQueryable<T> LoadEntites(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where);
        }

        public IQueryable<T> FindPagedList(int pageIndex, int pageSize, Expression<Func<T, bool>> where)
        {
            var list = _context.Set<T>().Where(where);
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return list;
        }

        public IQueryable<T> FindPagedList<S>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, bool isAsc)
        {
            var list = _context.Set<T>().Where(where);
            if (isAsc)
            {
                list = list.OrderBy<T, S>(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                list = list.OrderByDescending<T, S>(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return list;
        }

        public T AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public int DelEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
            return SaveChanges();
        }        
        
        public int UpdEntity(T entity)
        {
            _context.Set<T>().Update(entity);
            return SaveChanges();
        }
        

        public int AddList(params T[] entities)
        {
            int result = 0;
            for(int i = 0;i < entities.Count();i ++)
            {
                if(entities[i] == null)
                {
                    continue;
                }
                _context.Set<T>().Add(entities[i]);
                if (i != 0 && i % 20 == 0)
                {
                    result += _context.SaveChanges();
                }
            }
            if (entities.Count() > 0)
            {
                result += _context.SaveChanges();
            }
            return result;
        }

        public int RemoveList(Expression<Func<T, bool>> where)
        {
            var temp = _context.Set<T>().Where(where);
            foreach(var item in temp)
            {
                _context.Remove<T>(item);
            }
            return _context.SaveChanges();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }

}


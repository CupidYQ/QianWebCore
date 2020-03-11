using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IBLL;

namespace BLL
{
    public class BLLService<T> : IBLLService<T> where T : class, new()
    {
        protected IDAL.IDALService<T> idalService;
        
        public BLLService(IDAL.IDALService<T> dalService)
        {
            this.idalService = dalService;
        }

        public IQueryable<T> LoadEnitites(Expression<Func<T, bool>> where)
        {
            return idalService.LoadEntites(where);
        }

        public IQueryable<T> FindPagedList(int pageIndex, int pageSize, Expression<Func<T, bool>> where)
        {
            return idalService.FindPagedList(pageIndex, pageSize, where);
        }

        public IQueryable<T> FindPagedList<S>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, bool isAsc)
        {
            return idalService.FindPagedList(pageIndex, pageSize, where, orderBy, isAsc);
        }

        public T AddEntity(T entity, bool isSave)
        {
            entity = idalService.AddEntity(entity);
            if (isSave)
            {
                if (SaveChanges() > 0)
                    return null;
            }
            return entity;
        }

        public int DelEntity(T entity)
        {
            return idalService.DelEntity(entity);
        }
       
        
        public int UpdEntity(T entity)
        {
            return idalService.UpdEntity(entity);
        }

        public int SaveChanges()
        {
            return idalService.SaveChanges();
        }       
    }
}

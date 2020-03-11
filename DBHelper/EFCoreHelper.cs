using Qian.Shop.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DBHepler
{
    public class EFCoreHelper<T> where T : class
    {
        private readonly QianContext _context;
        public EFCoreHelper(QianContext context)
        {
            _context = context;
        }
        

        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entiy"></param>
        /// <returns></returns>
        public int Add(T entiy)
        {
            _context.Entry<T>(entiy).State = EntityState.Added;
            return _context.SaveChanges();
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entiy"></param>
        /// <returns></returns>
        public int Remove(T entiy)
        {
            _context.Entry<T>(entiy).State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entiy"></param>
        /// <returns></returns>
        public int Update(T entiy)
        {
            _context.Entry<T>(entiy).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        /// <summary>
        /// 批量新增实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int AddList(params T[] entities)
        {
            int result = 0;
            for(int i = 0;i < entities.Count();i++)
            {
                if (entities[i] == null)
                    continue;
                _context.Entry<T>(entities[i]).State = EntityState.Added;
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

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int RemoveList(Expression <Func<T,bool>> where)
        {
            var temp = _context.Set<T>().Where(where);
            foreach(var item in temp)
            {
                _context.Entry<T>(item).State = EntityState.Deleted;
            }
            return _context.SaveChanges();
        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression <Func<T,bool>> where)
        {
            var temp = _context.Set<T>().Where(where);
            return temp;
        }

        /// <summary>
        /// 按条件查询，分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> FindPagedList(int pageIndex,int pageSize,out int rowCount,Expression<Func<T,bool>> where)
        {
            var list = _context.Set<T>().Where(where);
            rowCount = list.Count();
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return list;
        }

        /// <summary>
        /// 按条件查询，分页，排序
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindPagedList<S>(int pageIndex,int pageSize,out int rowCount,Expression<Func<T,bool>> where, Expression<Func<T, S>> orderBy,bool isAsc)
        {
            var list = _context.Set<T>().Where(where);
            rowCount = list.Count();
            if (isAsc)
            {
                list = list.OrderBy<T,S>(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                list = list.OrderByDescending<T,S>(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }            
            return list;
        }
        
    }
}

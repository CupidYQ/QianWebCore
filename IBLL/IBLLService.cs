using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IBLL
{
    public interface IBLLService<T> where T:class,new()
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> LoadEnitites(Expression<Func<T, bool>> where);

        /// <summary>
        /// 按条件查询，分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> FindPagedList(int pageIndex, int pageSize,Expression<Func<T, bool>> where);

        /// <summary>
        /// 按条件查询，分页，排序
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>        
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IQueryable<T> FindPagedList<S>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, bool isAsc);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        T AddEntity(T entity,bool isSave);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int DelEntity(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UpdEntity(T entity);

        int SaveChanges();
    }
}

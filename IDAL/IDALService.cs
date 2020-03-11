using System;
using System.Linq;
using System.Linq.Expressions;

namespace IDAL
{
    public interface IDALService<T> where T:class,new()
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntites(Expression<Func<T, bool>> where);

        /// <summary>
        /// 按条件查询，分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> FindPagedList(int pageIndex, int pageSize, Expression<Func<T, bool>> where);

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
        IQueryable<T> FindPagedList<S>(int pageIndex, int pageSize,Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, bool isAsc);
              
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        T AddEntity(T entity);

        /// <summary>
        /// 批量增加实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
         int AddList(params T[] entities);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int DelEntity(T entity);

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int RemoveList(Expression<Func<T, bool>> where);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UpdEntity(T entity);

        int SaveChanges();
    }
}

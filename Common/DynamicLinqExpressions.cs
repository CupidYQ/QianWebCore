using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Common
{
    public static class DynamicLinqExpressions
    {
        public static Expression<Func<T, bool>> True<T>() => f => true;
        public static Expression<Func<T, bool>> False<T>() => f => false;

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.Or(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.And(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// 动态组合多排序字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="orderByExpression"></param>
        /// <returns></returns>
        public static IQueryable<T> ExpressionOrderBy<T>(this IQueryable<T> query,params Qian.Models.OrderModelField[] orderByExpression)
        {
            var parameter = Expression.Parameter(typeof(T), "o");
            if (orderByExpression != null && orderByExpression.Length > 0)
            {
                for (int i = 0; i < orderByExpression.Length; i++)
                {
                    //根据属性名获取属性
                    var property = typeof(T).GetProperty(orderByExpression[i].propertyName);
                    //创建一个访问属性的表达式
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    var orderByExp = Expression.Lambda(propertyAccess, parameter);


                    string OrderName = orderByExpression[i].isAsc ? "OrderBy" : "OrderByDescending";
                    if (i > 0)
                    {
                        OrderName = orderByExpression[i].isAsc ? "ThenBy" : "ThenByDescending";
                    }
                    else
                    {
                        OrderName = orderByExpression[i].isAsc ? "OrderBy" : "OrderByDescending";
                    }                                        
                    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), OrderName, new Type[] { typeof(T), property.PropertyType }, query.Expression, Expression.Quote(orderByExp));
                    query = query.Provider.CreateQuery<T>(resultExp);
                }
            }
            return query;
        }
    }
}

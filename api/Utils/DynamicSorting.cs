using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.Utils
{
    public static class DynamicSorting<T>
    {
        public static IQueryable<T> SortByDescending(IQueryable<T> queryable, string propertyName)
        {
            Expression<Func<T, object>> lambdaSortingExpression = GetLambda(propertyName);
            return queryable.OrderByDescending(lambdaSortingExpression);
        }

        public static IQueryable<T> SortyBy(IQueryable<T> queryable, string propertyName)
        {
            Expression<Func<T, object>> lambdaSortingExpression = GetLambda(propertyName);
            return queryable.OrderByDescending(lambdaSortingExpression);
        }

        private static Expression<Func<T, object>> GetLambda(string propertyName)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "x"); // equivalent to x => x.something
            MemberExpression property = Expression.Property(param, propertyName); // x => x.propertyName
            UnaryExpression convertedProperty = Expression.Convert(property, typeof(object)); // no matter what's the property type the delegate type still works
            
            return Expression.Lambda<Func<T, object>>(convertedProperty, param);
        }
    }
}
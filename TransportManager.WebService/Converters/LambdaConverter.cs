using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TransportManager.WebService.Converters
{
    public static class LambdaConverter
    {
        public static Expression<Func<TEntity, bool>> Convert<TEntity>(string expressionString) 
            where TEntity : class
        {
            string[] period = expressionString.Split('^');

            DateTime minParameter = System.Convert.ToDateTime(period[0]);
            DateTime maxParameter = System.Convert.ToDateTime(period[1]);

            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var member = Expression.Property(parameter, "LastVisit");
            var minConst = Expression.Constant(minParameter);
            var maxConst = Expression.Constant(maxParameter);
            var leftExpression = Expression.GreaterThanOrEqual(member, minConst);
            var rightExpression = Expression.LessThanOrEqual(member, maxConst);
            var body = Expression.And(leftExpression, rightExpression);
            var finalExpresstion = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

            return finalExpresstion;
        }
    }
}
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CamaraComercio.DataAccess.EF
{
    /// <summary>
    /// Constructor de predicados para where's dinámicos
    /// </summary>
    public static class PredicateBuilder
    {
        ///<summary>
        /// Expresión dinámica que siempre retorna verdadero
        ///</summary>
        /// <remarks>
        /// Se utiliza para iniciar la cadena de evaluación del Where
        /// </remarks>
        ///<typeparam name="T"></typeparam>
        ///<returns>True</returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }

        ///<summary>
        /// Expresión dinámica que siempre retorna falso
        ///</summary>
        /// <remarks>
        /// Se utiliza para iniciar la cadena de evaluación del Where
        /// </remarks>
        ///<typeparam name="T"></typeparam>
        ///<returns>False</returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        /// <summary>
        /// Expresión dinámica que concatena una evaluación disyuntiva a un Where
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// Expresión dinámica que concatena una evaluación conjuntiva a un Where
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}

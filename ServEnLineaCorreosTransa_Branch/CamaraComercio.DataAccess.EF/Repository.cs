using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace CamaraComercio.DataAccess.EF
{
    /// <summary>
    /// Clase que representa los repositorios de datos
    /// </summary>
    /// <typeparam name="E">Tipo de entidad a instanciar en el repositorio</typeparam>
    /// <typeparam name="C">Objecto del Entity Framework para el contexto de la base de datos (DBContext)</typeparam>
    public class Repository<E, C> : IRepository<E, C>, IDisposable
        where E : class
        where C : ObjectContext, new()
    {
        private readonly C _ctx;
        private string _KeyProperty = "ID";
        public string KeyProperty
        {
            get
            {
                return _KeyProperty;
            }
            set
            {
                _KeyProperty = value;
            }
        }
        public C Session
        {
            get { return _ctx; }
        }
        public Repository(C session)
        {
            _ctx = session;
        }

        public Repository()
        {
            _ctx = new C();
        }

        #region IRepository<E,C> Members

        public int Save()
        {
            return _ctx.SaveChanges();
        }
        /// <summary>
        /// Metodo genérico que retorna todas las entidades del modelo
        /// </summary>
        /// <param name="entitySetName">
        /// Nombre del EntitySet en el modelo.
        /// </param>
        /// <typeparam name="TEntity">
        /// Entidad a cargar desde la base de datos
        /// </typeparam>
        /// <returns>Un set del tipo TEntity.</returns>
        public ObjectQuery<E> DoQuery(string entitySetName)
        {
            return _ctx.CreateQuery<E>("[" + entitySetName + "]");
        }
        /// <summary>
        /// A generic method to return ALL the entities
        /// </summary>
        /// <typeparam name="TEntity">
        /// Entidad a cargar desde la base de datos
        /// </typeparam>
        /// <returns>Un set del tipo TEntity.</returns>
        public ObjectQuery<E> DoQuery()
        {
            return _ctx.CreateQuery<E>("[" + typeof(E).Name + "]");
        }

        /// <summary>
        /// </summary>
        /// <param name="entitySetName">
        /// Metodo genérico que retorna todas las entidades del modelo
        /// </param>
        /// <typeparam name="TEntity">
        /// Entidad a cargar desde la base de datos
        /// </typeparam>
        /// <returns>Un set del tipo TEntity.</returns>
        public ObjectQuery<E> DoQuery(string entitySetName, ISpecification<E> where)
        {
            return
                (ObjectQuery<E>)_ctx.CreateQuery<E>("[" + entitySetName + "]")
                .Where(where.EvalPredicate);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TEntity">
        /// Entidad a cargar desde la base de datos
        /// </typeparam>
        /// <returns>Un set del tipo TEntity.</returns>
        public ObjectQuery<E> DoQuery(ISpecification<E> where)
        {
            return
                (ObjectQuery<E>)_ctx.CreateQuery<E>("[" + typeof(E).Name + "]")
                .Where(where.EvalPredicate);
        }
        /// <summary>
        /// Entity Query con Paginación
        /// </summary>
        /// <param name="maximumRows">Maximo de rows a cargar</param>
        /// <param name="startRowIndex">Index de inicio</param>
        /// <returns>Colección de Entities</returns>
        public ObjectQuery<E> DoQuery(int maximumRows, int startRowIndex)
        {
            return (ObjectQuery<E>)_ctx.CreateQuery<E>
                ("[" + typeof(E).Name + "]").Skip<E>(startRowIndex).Take(maximumRows);
        }
        /// <summary>
        /// Entity Query en el orden especificado
        /// </summary>
        /// <param name="sortExpression">Expresion para sortear</param>
        /// <returns>Colección de entidades</returns>
        public ObjectQuery<E> DoQuery(Expression<Func<E, object>> sortExpression)
        {
            if (null == sortExpression)
            {
                return ((IRepository<E, C>)this).DoQuery();
            }
            return (ObjectQuery<E>)((IRepository<E, C>)this).DoQuery().OrderBy
                        <E, object>(sortExpression);
        }
        /// <summary>
        /// Query para todas las entidades en el orden especificado y con soporte para Paging
        /// </summary>
        /// <param name="sortExpression">Expresion para ordenar</param>
        /// <param name="maximumRows">Máximo de rows a cargar</param>
        /// <param name="startRowIndex">Index de inicio</param>
        /// <returns>Colección de Entidads</returns>
        public ObjectQuery<E> DoQuery(Expression<Func<E, object>>
            sortExpression, int maximumRows, int startRowIndex)
        {
            if (sortExpression == null)
            {
                return ((IRepository<E, C>)this).DoQuery(maximumRows, startRowIndex);
            }
            return (ObjectQuery<E>)((IRepository<E, C>)this).DoQuery
            (sortExpression).Skip<E>(startRowIndex).Take(maximumRows);
        }
        /// <summary>
        /// Método genérico que retorna todas las entidades
        /// </summary>
        /// <param name="entitySetName">
        /// Nombre del entityset en el modelo
        /// </param>
        /// <typeparam name="TEntity">
        /// Entidad a cargar desde la base de datos
        /// </typeparam>
        /// <returns>Un set del tipo TEntity.</returns>
        public IList<E> SelectAll(string entitySetName)
        {
            return DoQuery(entitySetName).ToList();
        }

        /// <summary>
        /// Método genérico que retorna todas las entidades
        /// </summary>
        /// <returns>Un set del tipo TEntity.</returns>
        public IList<E> SelectAll()
        {
            try
            {
                return DoQuery().ToList(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método genérico que retorna todas las entidades
        /// </summary>
        /// <param name="entitySetName">
        /// Nombre del EntitySet en el modelo
        /// </param>
        /// <returns>Un set del tipo TEntity.</returns>
        public IList<E> SelectAll(string entitySetName, ISpecification<E> where)
        {
            return DoQuery(entitySetName, where).ToList();
        }

        /// <summary>
        /// Método genérico que retorna todas las entidades
        /// </summary>
        /// Entidad a cargar desde la base de datos
        /// </typeparam>
        /// <returns>Un set del tipo TEntity.</returns>
        public IList<E> SelectAll(ISpecification<E> where)
        {
            return DoQuery(where).ToList();
        }
        /// <summary>
        /// <summary>
        /// Entity Query con Paginación
        /// </summary>
        /// <param name="maximumRows">Maximo de rows a cargar</param>
        /// <param name="startRowIndex">Index de inicio</param>
        /// <returns>Colección de Entities</returns>
        public IList<E> SelectAll(int maximumRows, int startRowIndex)
        {
            return DoQuery(maximumRows, startRowIndex).ToList();
        }
        /// <summary>
        /// Selecciona todas las entidades en el orden especificado
        /// </summary>
        /// <param name="sortExpression">Expresion para ordenar</param>
        /// <returns>Colección de Entities</returns>
        public IList<E> SelectAll(Expression<Func<E, object>> sortExpression)
        {
            if (null == sortExpression)
            {
                return DoQuery(sortExpression).ToList();
            }
            return DoQuery(sortExpression).ToList();
        }
        /// <summary>
        /// Selecciona todas las entidades con soporte de paginacion y filtro
        /// </summary>
        /// <param name="sortExpression">Expresión para ordenar</param>
        /// <param name="maximumRows">Máximo de rows a cargar</param>
        /// <param name="startRowIndex">Index de inicio</param>
        /// <returns>Colección de Entities</returns>
        public IList<E> SelectAll(Expression<Func<E, object>>
            sortExpression, int maximumRows, int startRowIndex)
        {
            if (sortExpression == null)
            {
                return DoQuery(maximumRows, startRowIndex).ToList();
            }
            return DoQuery(sortExpression, maximumRows, startRowIndex).ToList();
        }
        
        /// <summary>
        /// Obtiene el Entity por su llave primaria (siempre y cuando se llame ID)
        /// </summary>
        /// <typeparam name="E">Tipo de Entidad</typeparam>
        /// <param name="key">Valor a buscar</param>
        /// <returns>return entity</returns>
        public E SelectByKey(int key)
        {
            // First we define the parameter that we are going to use the clause. 
            var xParam = Expression.Parameter(typeof(E), typeof(E).Name);
            var leftExpr = MemberExpression.Property(xParam, this._KeyProperty);
            var rightExpr = Expression.Constant(key);
            BinaryExpression binaryExpr = MemberExpression.Equal(leftExpr, rightExpr);
            //Create Lambda Expression for the selection 
            var lambdaExpr = Expression.Lambda<Func<E, bool>>(binaryExpr,
            new ParameterExpression[] { xParam });
            //Searching ....
            var resultCollection = ((IRepository<E, C>)this).SelectAll(new Specification<E>(lambdaExpr));
            if (null != resultCollection && resultCollection.Count() > 0)
            {
                //return valid single result
                return resultCollection.First<E>();
            }//end if 
            return null;
        }


        /// <summary>
        /// Obtiene el Entity por la llave especificada
        /// </summary>
        /// <typeparam name="E">Tipo de Entidad</typeparam>
        /// <param name="keyProperty">Llave por la cual se desea buscar el query</param>
        /// <param name="key">Valor a buscar</param>
        /// <returns>return entity</returns>
        public E SelectByKey(string keyProperty, object key)
        {
            // First we define the parameter that we are going to use the clause. 
            var xParam = Expression.Parameter(typeof(E), typeof(E).Name);
            var leftExpr = MemberExpression.Property(xParam, keyProperty);
            var rightExpr = Expression.Constant(key);
            BinaryExpression binaryExpr = MemberExpression.Equal(leftExpr, rightExpr);
            //Create Lambda Expression for the selection 
            var lambdaExpr = Expression.Lambda<Func<E, bool>>(binaryExpr,
            new ParameterExpression[] { xParam });
            //Searching ....
            var resultCollection = ((IRepository<E, C>)this).SelectAll(new Specification<E>(lambdaExpr));
            if (null != resultCollection && resultCollection.Count() > 0)
            {
                //return valid single result
                return resultCollection.First<E>();
            }//end if 
            return null;
        }

        /// <summary>
        /// Check if value of specific field is already exist
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="fieldName">name of the Field</param>
        /// <param name="fieldValue">Field value</param>
        /// <param name="key">Primary key value</param>
        /// <returns>True or False</returns>
        public bool TrySameValueExist(string fieldName, object fieldValue, string key)
        {
            // First we define the parameter that we are going to use the clause. 
            var xParam = Expression.Parameter(typeof(E), typeof(E).Name);
            MemberExpression leftExprFieldCheck =
            MemberExpression.Property(xParam, fieldName);
            Expression rightExprFieldCheck = Expression.Constant(fieldValue);
            BinaryExpression binaryExprFieldCheck =
            MemberExpression.Equal(leftExprFieldCheck, rightExprFieldCheck);

            MemberExpression leftExprKeyCheck =
            MemberExpression.Property(xParam, this._KeyProperty);
            Expression rightExprKeyCheck = Expression.Constant(key);
            BinaryExpression binaryExprKeyCheck =
            MemberExpression.NotEqual(leftExprKeyCheck, rightExprKeyCheck);
            BinaryExpression finalBinaryExpr =
            Expression.And(binaryExprFieldCheck, binaryExprKeyCheck);

            //Create Lambda Expression for the selection 
            Expression<Func<E, bool>> lambdaExpr =
            Expression.Lambda<Func<E, bool>>(finalBinaryExpr,
            new ParameterExpression[] { xParam });
            //Searching ....            
            return ((IRepository<E, C>)this).TryEntity(new Specification<E>(lambdaExpr));
        }
        /// <summary>
        /// Check if Entities exist with Condition
        /// </summary>
        /// <param name="selectExpression">Selection Condition</param>
        /// <returns>True or False</returns>
        public bool TryEntity(ISpecification<E> selectSpec)
        {
            return _ctx.CreateQuery<E>("[" + typeof(E).Name + "]").Any<E>
                        (selectSpec.EvalPredicate);
        }
        /// <summary>
        /// Get Count of all records
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <returns>count of all records</returns>
        public int GetCount()
        {
            return _ctx.CreateQuery<E>("[" + typeof(E).Name + "]").Count();
        }
        /// <summary>
        /// Get count of selection
        /// </summary>
        /// <typeparam name="E">Selection Condition</typeparam>
        /// <returns>count of selection</returns>
        public int GetCount(ISpecification<E> selectSpec)
        {
            return _ctx.CreateQuery<E>("[" + typeof(E).Name + "]")
                .Where(selectSpec.EvalPredicate).Count();
        }
        /// <summary>
        /// Delete data from context
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="entity"></param>
        public void Delete(E entity)
        {
            _ctx.DeleteObject(entity);
        }
        /// <summary>
        /// Delete data from context
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="entity"></param>
        public void Delete(object entity)
        {
            _ctx.DeleteObject(entity);
        }
        /// <summary>
        /// Insert new data into context
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="entity"></param>
        public void Add(E entity)
        {
            _ctx.AddObject(entity.GetType().Name, entity);
        }
        /// <summary>
        /// Start Transaction
        /// </summary>
        /// <returns></returns>
        public DbTransaction BeginTransaction()
        {
            if (_ctx.Connection.State != ConnectionState.Open)
            {
                _ctx.Connection.Open();
            }
            return _ctx.Connection.BeginTransaction();
        }
        /// <summary>
        /// Delete all related entries
        /// </summary>
        /// <param name="entity"></param>        
        public void DeleteRelatedEntries(E entity)
        {
            foreach (var relatedEntity in (((IEntityWithRelationships)entity).
        RelationshipManager.GetAllRelatedEnds().SelectMany(re =>
        re.CreateSourceQuery().OfType<EntityObject>()).Distinct()).ToArray())
            {
                _ctx.DeleteObject(relatedEntity);
            }//end foreach
        }
        /// <summary>
        /// Delete all related entries
        /// </summary>
        /// <param name="entity"></param>        
        public void DeleteRelatedEntries(E entity, ObservableCollection<string>
                            keyListOfIgnoreEntites)
        {
            foreach (var relatedEntity in (((IEntityWithRelationships)entity).
            RelationshipManager.GetAllRelatedEnds().SelectMany(re =>
            re.CreateSourceQuery().OfType<EntityObject>()).Distinct()).ToArray())
            {
                PropertyInfo propInfo = relatedEntity.GetType().GetProperty
                            (this._KeyProperty);
                if (null != propInfo)
                {
                    string value = (string)propInfo.GetValue(relatedEntity, null);
                    if (!string.IsNullOrEmpty(value) &&
                        keyListOfIgnoreEntites.Contains(value))
                    {
                        continue;
                    }//end if 
                }//end if
                _ctx.DeleteObject(relatedEntity);
            }//end foreach
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (null != _ctx)
            {
                _ctx.Dispose();
            }
        }

        #endregion

    }

    /// <summary>
    /// Especificacion del objeto a construir dentro del repositorio
    /// </summary>
    /// <typeparam name="E">Tipo de entidad</typeparam>
    public class Specification<E> : ISpecification<E>
    {
        #region Private Members

        private Func<E, bool> _evalFunc = null;
        private Expression<Func<E, bool>> _evalPredicate;

        #endregion

        #region Virtual Accessors

        /// <summary>
        /// Expresion dinámica por la cual se generarn queries de Linq
        /// </summary>
        public virtual Expression<Func<E, bool>> EvalPredicate
        {
            get { return _evalPredicate; }
        }

        /// <summary>
        /// Función anónima para llamadas al objeto especificado
        /// </summary>
        public virtual Func<E, bool> EvalFunc
        {
            get { return _evalFunc; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="predicate">Predicado con el que se hace el where para el query de linq</param>
        public Specification(Expression<Func<E, bool>> predicate)
        {
            _evalPredicate = predicate;
        }

        private Specification() { }

        #endregion
    }
}

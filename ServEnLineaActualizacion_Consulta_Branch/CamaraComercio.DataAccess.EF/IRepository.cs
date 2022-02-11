using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CamaraComercio.DataAccess.EF
{
    /// <summary>
    /// Interfaz que define la funcionalidad basica del repositorio. 
    /// Se puede implementar para cada controlador o simplemente hacer una clase genérica que se instancie para cada tipo
    /// </summary>
    /// <typeparam name="T">
    /// Tipo de entidad (de System.Data.Entity)
    /// </typeparam>
    public interface IRepository<E, C>
    {
        ///<summary>
        /// Método que inicia la transaccion en la base de datos
        ///</summary>
        ///<returns></returns>
        DbTransaction BeginTransaction();
        
        /// <summary>
        /// Método que agrega una nueva entidad al repositorio
        /// </summary>
        /// <param name="entity"></param>
        void Add(E entity);

        /// <summary>
        /// Método que borra entidades relacionadas con la entidad instanciada en el repositorio
        /// </summary>
        /// <param name="entity">Tipo de entidad a borrar</param>
        void DeleteRelatedEntries(E entity);
        
        /// <summary>
        /// Método que borra entidades relacionadas con la entidad instanciada en el repositorio (sobrecarga)
        /// </summary>
        /// <param name="entity">Tipo de entidad a borrar</param>
        /// <param name="keyListOfIgnoreEntites">Lista de entidades a ignorar</param>
        void DeleteRelatedEntries(E entity, ObservableCollection<string> keyListOfIgnoreEntites);
        
        /// <summary>
        /// Método que borra una entidad del repositorio
        /// </summary>
        /// <param name="entity"></param>
        void Delete(E entity);
        
        /// <summary>
        /// Método que persiste los cambios realizados a la base de datos
        /// </summary>
        /// <returns></returns>
        int Save();

        /// <summary>
        /// Ejecución del Query
        /// </summary>
        /// <param name="entitySetName">Nombre del set de entidades</param>
        /// <returns></returns>
        ObjectQuery<E> DoQuery(string entitySetName);
        
        /// <summary>
        /// Ejecución del Query (default)
        /// </summary>
        /// <returns></returns>
        ObjectQuery<E> DoQuery();
        
        /// <summary>
        /// Ejecución del Query
        /// </summary>
        /// <param name="entitySetName">Nombre del set de entidades</param>
        /// <param name="where">Predicado (Where)</param>
        /// <returns></returns>
        ObjectQuery<E> DoQuery(string entitySetName, ISpecification<E> where);
        
        /// <summary>
        /// Ejecución del Query
        /// </summary>
        /// <param name="where">Predicado (Where)</param>
        /// <returns></returns>
        ObjectQuery<E> DoQuery(ISpecification<E> where);

        /// <summary>
        /// Ejecución paginada del Query
        /// </summary>
        /// <param name="maximumRows">Cantidad máxima a traer de rows</param>
        /// <param name="startRowIndex">Índice de inicio</param>
        /// <returns></returns>
        ObjectQuery<E> DoQuery(int maximumRows, int startRowIndex);
        
        /// <summary>
        /// Ejecución Ordenada del Query (Sorted)
        /// </summary>
        /// <param name="sortExpression">Expresión de orden (sort)</param>
        /// <returns></returns>
        ObjectQuery<E> DoQuery(Expression<Func<E, object>> sortExpression);

        /// <summary>
        /// Ejecución paginada y ordenada del Query
        /// </summary>
        /// <param name="sortExpression">Expresión de orden (sort)</param>
        /// <param name="maximumRows">Cantidad máxima a traer de rows</param>
        /// <param name="startRowIndex">Índice de inicio</param>
        /// <returns></returns>
        ObjectQuery<E> DoQuery(Expression<Func<E, object>> sortExpression,
                    int maximumRows, int startRowIndex);

        /// <summary>
        /// Selección de todos los objetos en el repositorio
        /// </summary>
        /// <param name="entitySetName">Nombre del set de entidades</param>
        /// <returns></returns>
        IList<E> SelectAll(string entitySetName);
        
        /// <summary>
        /// Selección de todos los objetos en el repositorio (default)
        /// </summary>
        /// <returns></returns>
        IList<E> SelectAll();

        /// <summary>
        /// Selección de todos los objetos en el repositorio
        /// </summary>
        /// <param name="entitySetName">Nombre del set de entidades</param>
        /// <param name="where">Predicado (Where)</param>
        /// <returns></returns>
        IList<E> SelectAll(string entitySetName, ISpecification<E> where);
        
        /// <summary>
        /// Selección de todos los objetos en el repositorio
        /// </summary>
        /// <param name="where">Predicado (Where)</param>
        /// <returns></returns>
        IList<E> SelectAll(ISpecification<E> where);
        
        /// <summary>
        /// Selección de todos los objetos en el repositorio
        /// </summary>
        /// <param name="maximumRows">Cantidad máxima a traer de rows</param>
        /// <param name="startRowIndex">Índice de inicio</param>
        /// <returns></returns>
        IList<E> SelectAll(int maximumRows, int startRowIndex);
        
        /// <summary>
        /// Selección de todos los objetos en el repositorio (sorted)
        /// </summary>
        /// <param name="sortExpression">Expresión de orden (sort)</param>
        /// <returns></returns>
        IList<E> SelectAll(Expression<Func<E, object>> sortExpression);
        
        /// <summary>
        /// Selección de todos los objetos en el repositorio. Ordenada y paginada
        /// </summary>
        /// <param name="sortExpression">Expresión de orden (sort)</param>
        /// <param name="maximumRows">Cantidad máxima a traer de rows</param>
        /// <param name="startRowIndex">Índice de inicio</param>
        /// <returns></returns>
        IList<E> SelectAll(Expression<Func<E, object>> sortExpression,
                    int maximumRows, int startRowIndex);

        /// <summary>
        /// Selección de un objeto por llave primaria (int)
        /// </summary>
        /// <param name="key">Valor a filtrar</param>
        /// <returns></returns>
        E SelectByKey(int key);

        /// <summary>
        /// Seleccón de un objeto por llave específica
        /// </summary>
        /// <param name="keyProperty">Nombre de la propiedad considerada llave</param>
        /// <param name="key">Valor a filtrar</param>
        /// <returns></returns>
        E SelectByKey(string keyProperty, object key);

        /// <summary>
        /// Comprobación de un valor previo existente en el repositorio
        /// </summary>
        /// <param name="fieldName">Nombre del campo</param>
        /// <param name="fieldValue">Valor a comparar</param>
        /// <param name="key">Nombre de la llave</param>
        /// <returns></returns>
        bool TrySameValueExist(string fieldName, object fieldValue, string key);
        
        /// <summary>
        /// Intento de conversión a la entidad
        /// </summary>
        /// <param name="selectSpec">Especificación de la entidad</param>
        /// <returns></returns>
        bool TryEntity(ISpecification<E> selectSpec);

        /// <summary>
        /// Retorna el total de registros en la base de datos
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// Retorna el total de registros en la base de datos. Filtrado por un predicado.
        /// </summary>
        /// <param name="selectSpec">Predicado (where)</param>
        /// <returns></returns>
        int GetCount(ISpecification<E> selectSpec);
    }

    /// <summary>
    /// Interfaz que permite la definición de where's dinámicos
    /// </summary>
    /// <typeparam name="E">Tipo de entidad</typeparam>
    public interface ISpecification<E>
    {
        /// <summary>
        /// Expresion Select/Where
        /// </summary>
        Expression<Func<E, bool>> EvalPredicate { get; }
        /// <summary>
        /// Funcion para evaluar el Where
        /// </summary>
        Func<E, bool> EvalFunc { get; }
    }
}

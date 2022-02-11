using System;
using System.ComponentModel;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class RequisitoController
    {
        /// <summary>
        /// Obtiene la coleccion de requisitos para la transformacion de un tipo de sociedad actual a otra
        /// </summary>
        /// <param name="tipoSociedadActualID"></param>
        /// <param name="tipoSociedadID"></param>
        /// <param name="tipoAcciones"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public RequisitoCollection FetchTransformOptions(int? tipoSociedadActualID, int? tipoSociedadID,
                                                         TipoAcciones tipoAcciones)
        {
            RequisitoCollection requisitos = new RequisitoCollection();

            try
            {
                //Construccion del Select
                SqlQuery query = new Select().From(Requisito.Schema);

                //Sociedad Actual
                if (tipoSociedadActualID == null)
                    query.And(Requisito.TipoSociedadActualIdColumn).IsNull();
                else
                    query.And(Requisito.TipoSociedadActualIdColumn).IsEqualTo(tipoSociedadActualID);

                //Sociedad Nueva
                if (tipoSociedadID == null)
                    query.And(Requisito.TipoSociedadIdColumn).IsNull();
                else
                    query.And(Requisito.TipoSociedadIdColumn).IsEqualTo(tipoSociedadID);

                //Tipo de acciones
                query.And(Requisito.TipoAccionesColumn).IsEqualTo((int) tipoAcciones);

                //Exclusion de renovacion
                query.And(Requisito.IncluirEnRenovacionColumn).IsEqualTo(false);

                //Llamada a la base de datos
                requisitos = query.ExecuteAsCollection<RequisitoCollection>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return requisitos;
        }

        /// <summary>
        /// /// Obtiene la coleccion de requisitos para la transformacion de un tipo de sociedad actual a otra
        /// </summary>
        /// <param name="tipoSociedadId"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public RequisitoCollection FetchRequisitosRenovacion(int? tipoSociedadID, TipoAcciones tipoAcciones)
        {
            RequisitoCollection requisitos = new RequisitoCollection();

            if (tipoSociedadID == null)
                return requisitos;

            try
            {
                //Construccion del Select
                SqlQuery query = new Select().From(Requisito.Schema).
                    And(Requisito.TipoSociedadIdColumn).IsEqualTo(tipoSociedadID).
                    And(Requisito.TipoAccionesColumn).IsEqualTo(tipoAcciones).
                    And(Requisito.IncluirEnRenovacionColumn).IsEqualTo(true);

                //Llamada a la base de datos
                requisitos = query.ExecuteAsCollection<RequisitoCollection>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return requisitos;
        }

        public enum TipoAcciones
        {
            Privada = 1,
            Publica = 2,
            Extranjera = 3
        }
    }
}
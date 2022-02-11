//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public partial class TiposTareas
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string TipoTareaId = @"TipoTareaId";
    public static string Descripcion = @"Descripcion";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int TipoTareaId
        {
            get;
            set;
        }
    
        public virtual string Descripcion
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual ICollection<Agenda> Agenda
        {
            get
            {
                if (_agenda == null)
                {
                    var newCollection = new FixupCollection<Agenda>();
                    newCollection.CollectionChanged += FixupAgenda;
                    _agenda = newCollection;
                }
                return _agenda;
            }
            set
            {
                if (!ReferenceEquals(_agenda, value))
                {
                    var previousValue = _agenda as FixupCollection<Agenda>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAgenda;
                    }
                    _agenda = value;
                    var newValue = value as FixupCollection<Agenda>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAgenda;
                    }
                }
            }
        }
        private ICollection<Agenda> _agenda;

        #endregion

        #region Association Fixup
    
        private void FixupAgenda(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Agenda item in e.NewItems)
                {
                    item.TiposTareas = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Agenda item in e.OldItems)
                {
                    if (ReferenceEquals(item.TiposTareas, this))
                    {
                        item.TiposTareas = null;
                    }
                }
            }
        }

        #endregion

    }
}

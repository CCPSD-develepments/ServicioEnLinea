using System;
using System.Runtime.Serialization;

namespace CamaraComercio.FormsManager
{
    public class FormManagerException : Exception
    {
        public FormManagerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        public FormManagerException(string message) : base(message)
        {
        }

        public FormManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
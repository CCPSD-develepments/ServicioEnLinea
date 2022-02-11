using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
#pragma warning disable CS0105 // The using directive for 'System.Xml.Linq' appeared previously in this namespace
using System.Xml.Linq;
#pragma warning restore CS0105 // The using directive for 'System.Xml.Linq' appeared previously in this namespace
using System.Reflection.Emit;
using System.Collections;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute'
    public class ControlNameAttribute : Attribute
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.id'
        public String id { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.id'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.controlSRM'
        public String controlSRM { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.controlSRM'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.fieldType'
        public FieldType fieldType { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.fieldType'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.isMandatory'
        public bool isMandatory { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.isMandatory'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.maxInstances'
        public int maxInstances { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.maxInstances'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.maxLength'
        public int maxLength { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.maxLength'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.isNumber'
        public bool isNumber { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.isNumber'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.NombreControl'
        public string NombreControl { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ControlNameAttribute.NombreControl'
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FieldType'
    public enum FieldType
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FieldType'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FieldType.Text'
        Text = 0,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FieldType.Text'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FieldType.DropDown'
        DropDown = 1
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FieldType.DropDown'
    }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaEjemplo'
    public class PersonaEjemplo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaEjemplo'
    {
        [ControlName(NombreControl = "Hola")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaEjemplo.Edad'
        public int Edad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaEjemplo.Edad'

        [ControlName(NombreControl = "ComoEstas")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaEjemplo.Sexo'
        public string Sexo { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaEjemplo.Sexo'

        [ControlName(NombreControl = "TodoBien")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaEjemplo.test'
        public List<int> test { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaEjemplo.test'

    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'XElementExtensions'
    public static class XElementExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'XElementExtensions'
    {
        private static XName _nillableAttributeName = "{http://www.w3.org/2001/XMLSchema-instance}nil";

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'XElementExtensions.SetNillableElementValue(XElement, XName, object)'
        public static void SetNillableElementValue(this XElement parentElement, XName elementName, object value)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'XElementExtensions.SetNillableElementValue(XElement, XName, object)'
        {
            parentElement.SetElementValue(elementName, value);
            parentElement.Element(elementName).MakeNillable();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'XElementExtensions.MakeNillable(XElement)'
        public static XElement MakeNillable(this XElement element)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'XElementExtensions.MakeNillable(XElement)'
        {
            var hasNillableAttribute = element.Attribute(_nillableAttributeName) != null;
            if (string.IsNullOrEmpty(element.Value))
            {
                if (!hasNillableAttribute)
                    element.Add(new XAttribute(_nillableAttributeName, true));
            }
            else
            {
                if (hasNillableAttribute)
                    element.Attribute(_nillableAttributeName).Remove();
            }
            return element;
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>'
    public static class Serializer<T> where T : class, new()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>'
    {
        private static Dictionary<Type, PropertyInfo[]> props =
            new Dictionary<Type, PropertyInfo[]>();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.Serialize(T)'
        public static string Serialize(T instance)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.Serialize(T)'
        {
            Type t = typeof(T);
            PropertyInfo[] pis = null;
            lock (props)
            {
                if (!props.TryGetValue(t, out pis))
                {
                    PropertyInfo[] ps = t.GetProperties(
                        BindingFlags.Public |
                        BindingFlags.GetProperty |
                        BindingFlags.Instance);
                    props.Add(t, ps);
                }
                pis = props[t];
            }

            XElement xd = new XElement(t.Name.Replace("`", ""));
            List<PropertyInfo> info = new List<PropertyInfo>(pis);
            XElement fields = new System.Xml.Linq.XElement("fields");

            info.ForEach(p =>
            {

                XElement textField = new System.Xml.Linq.XElement("TextField");
                XElement name = new System.Xml.Linq.XElement("name");
                XElement values = new System.Xml.Linq.XElement("values");
                XElement isNumber = new System.Xml.Linq.XElement("isNumber");

                string fieldId = String.Empty;

                var attr = p.GetCustomAttributes(true).Cast<Attribute>();

                var query = (from a in attr
                             where a is ControlNameAttribute
                             select a as ControlNameAttribute).FirstOrDefault();

                if (query != null)
                {
                    foreach (var pro in typeof(ControlNameAttribute).GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.DeclaredOnly).OrderBy(a => a.Name))
                    {
                        var value = pro.GetValue(query, null);
                        if (value == null)
                            value = "null";

                        if (pro.Name == "id")
                            fieldId = name.Value = value.ToString();

                        if (pro.Name == "isNumber")
                            isNumber.Value = value.ToString();

                        XAttribute at = new System.Xml.Linq.XAttribute(pro.Name, value);
                        textField.Add(at);

                    }
                }

                object val = null;
                //PropertyCaller<T, T>.GenGetter g =
                //PropertyCaller<T, T>.CreateGetMethod(p);
                //val = g(instance);
                val = p.GetValue(instance, null);
                XElement xa = new XElement("value");
                //if (val == null)
                //    val = "null";
                if (val is ICollection)
                {
                    var collection = val as IEnumerable;
                    var Iterator = collection.GetEnumerator();

                    while (Iterator.MoveNext())
                        xa.Add(SerializeElement(Iterator.Current));
                }
                else
                {
                    if (val != null)
                        xa.Add(new XAttribute("contents", val));
                }


                xa.Add(new XAttribute("fieldId", fieldId));

                values.Add(xa);
                textField.Add(name);
                textField.Add(values);
                textField.Add(isNumber);
                fields.Add(textField);
            });

            xd.Add(fields);
            return xd.ToString();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.SerializeElement<K>(K)'
        public static XElement SerializeElement<K>(K instance)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.SerializeElement<K>(K)'
        {
            Type t = instance.GetType();
            if (t.IsPrimitive)
                return new XElement("contents", instance.ToString());
            PropertyInfo[] pis = null;
            lock (props)
            {
                if (!props.TryGetValue(t, out pis))
                {
                    PropertyInfo[] ps = t.GetProperties(
                        BindingFlags.Public |
                        BindingFlags.GetProperty |
                        BindingFlags.Instance);
                    props.Add(t, ps);
                }
                pis = props[t];
            }

            XElement xd = new XElement(t.Name);
            List<PropertyInfo> info = new List<PropertyInfo>(pis);
            info.ForEach(p =>
            {
                object val = null;

                val = p.GetValue(instance, null);

                XElement xa = new XElement(p.Name, val);

                xd.Add(xa);
            });

            return xd;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>'
#pragma warning disable CS0693 // Type parameter 'T' has the same name as the type parameter from outer type 'Serializer<T>'
        public sealed class PropertyCaller<T, K> where T : class
#pragma warning restore CS0693 // Type parameter 'T' has the same name as the type parameter from outer type 'Serializer<T>'
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>'
        {
            private static Dictionary<Type, Dictionary<Type, Dictionary<string, GenGetter>>> dGets =
                new Dictionary<Type, Dictionary<Type, Dictionary<string, GenGetter>>>();
            private static Dictionary<Type, Dictionary<Type, Dictionary<string, GenSetter>>> dSets =
                new Dictionary<Type, Dictionary<Type, Dictionary<string, GenSetter>>>();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>.GenSetter'
            public delegate void GenSetter(T target, K value);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>.GenSetter'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>.GenGetter'
            public delegate K GenGetter(T target);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>.GenGetter'

            private PropertyCaller()
            {
            }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>.CreateGetMethod(PropertyInfo)'
            public static GenGetter CreateGetMethod(PropertyInfo pi)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>.CreateGetMethod(PropertyInfo)'
            {
                //Create the locals needed.
                Type classType = typeof(T);
                Type returnType = typeof(K);
                string propertyName = pi.Name;

                //Let’s return the cached delegate if we have one.
                if (dGets.ContainsKey(classType))
                {
                    if (dGets[classType].ContainsKey(returnType))
                    {
                        if (dGets[classType][returnType].ContainsKey(propertyName))
                            return dGets[classType][returnType][propertyName];
                    }
                }

                //If there is no getter, return nothing
                MethodInfo getMethod = pi.GetGetMethod();
                if (getMethod == null)
                    return null;

                //Create the dynamic method to wrap the internal get method
                Type[] arguments = new Type[1];
                arguments[0] = typeof(T);

                DynamicMethod getter = new DynamicMethod(
                    String.Concat("_Get", pi.Name, "_"),
                    typeof(K),
                    new Type[] { typeof(T) },
                    pi.DeclaringType);
                ILGenerator gen = getter.GetILGenerator();
                gen.DeclareLocal(typeof(K));
                gen.Emit(OpCodes.Ldarg_0);
                gen.Emit(OpCodes.Castclass, pi.DeclaringType);
                gen.EmitCall(OpCodes.Callvirt, getMethod, null);
                gen.Emit(OpCodes.Ret);

                //Create the delegate and return it
                GenGetter genGetter = (GenGetter)getter.CreateDelegate(typeof(GenGetter));

                //Cache the delegate for future use.
                Dictionary<Type, Dictionary<string, GenGetter>> tempDict = null;
                Dictionary<string, GenGetter> tempPropDict = null;
                if (!dGets.ContainsKey(classType))
                {
                    tempPropDict = new Dictionary<string, GenGetter>();
                    tempPropDict.Add(propertyName, genGetter);
                    tempDict = new Dictionary<Type, Dictionary<string, GenGetter>>();
                    tempDict.Add(returnType, tempPropDict);
                    dGets.Add(classType, tempDict);
                }
                else
                {
                    if (!dGets[classType].ContainsKey(returnType))
                    {
                        tempPropDict = new Dictionary<string, GenGetter>();
                        tempPropDict.Add(propertyName, genGetter);
                        dGets[classType].Add(returnType, tempPropDict);
                    }
                    else
                    {
                        if (!dGets[classType][returnType].ContainsKey(propertyName))
                            dGets[classType][returnType].Add(propertyName, genGetter);
                    }
                }
                //Return delegate to the caller.
                return genGetter;
            }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>.CreateSetMethod(PropertyInfo)'
            public static GenSetter CreateSetMethod(PropertyInfo pi)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Serializer<T>.PropertyCaller<T, K>.CreateSetMethod(PropertyInfo)'
            {
                //Create the locals needed.
                Type classType = typeof(T);
                Type returnType = typeof(K);
                string propertyName = pi.Name;

                //Let’s return the cached delegate if we have one.
                if (dSets.ContainsKey(classType))
                {
                    if (dSets[classType].ContainsKey(returnType))
                    {
                        if (dSets[classType][returnType].ContainsKey(propertyName))
                            return dSets[classType][returnType][propertyName];
                    }
                }

                //If there is no setter, return nothing
                MethodInfo setMethod = pi.GetSetMethod();
                if (setMethod == null)
                    return null;

                //Create dynamic method
                Type[] arguments = new Type[2];
                arguments[0] = typeof(T);
                arguments[1] = typeof(K);

                DynamicMethod setter = new DynamicMethod(
                    String.Concat("_Set", pi.Name, "_"),
                    typeof(void),
                    arguments,
                    pi.DeclaringType);
                ILGenerator gen = setter.GetILGenerator();
                gen.Emit(OpCodes.Ldarg_0);
                gen.Emit(OpCodes.Castclass, pi.DeclaringType);
                gen.Emit(OpCodes.Ldarg_1);

                if (pi.PropertyType.IsClass)
                    gen.Emit(OpCodes.Castclass, pi.PropertyType);

                gen.EmitCall(OpCodes.Callvirt, setMethod, null);
                gen.Emit(OpCodes.Ret);

                //Create the delegate
                GenSetter genSetter = (GenSetter)setter.CreateDelegate(typeof(GenSetter));

                //Cache the delegate for future use.
                Dictionary<Type, Dictionary<string, GenSetter>> tempDict = null;
                Dictionary<string, GenSetter> tempPropDict = null;
                if (!dSets.ContainsKey(classType))
                {
                    tempPropDict = new Dictionary<string, GenSetter>();
                    tempPropDict.Add(propertyName, genSetter);
                    tempDict = new Dictionary<Type, Dictionary<string, GenSetter>>();
                    tempDict.Add(returnType, tempPropDict);
                    dSets.Add(classType, tempDict);
                }
                else
                {
                    if (!dSets[classType].ContainsKey(returnType))
                    {
                        tempPropDict = new Dictionary<string, GenSetter>();
                        tempPropDict.Add(propertyName, genSetter);
                        dSets[classType].Add(returnType, tempPropDict);
                    }
                    else
                    {
                        if (!dSets[classType][returnType].ContainsKey(propertyName))
                            dSets[classType][returnType].Add(propertyName, genSetter);
                    }
                }
                //Return delegate to the caller.
                return genSetter;
            }
        }
    }

}

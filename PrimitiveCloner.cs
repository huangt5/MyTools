using System;
using System.Linq;
using System.Reflection;

namespace RuntimeUtil.Model {
    public class PrimitiveCloner {
        private Type _targetType;

        public PrimitiveCloner(Type targetType) {
            _targetType = targetType;
        }

        public void Clone(object from, object to) {
            if (from == null || to == null) {
                throw new Exception("Can not clone null object.");
            }

            if (from.GetType() != _targetType || to.GetType() != _targetType) {
                throw new Exception("Type does not match when cloning.");
            }

            foreach (PropertyInfo prop in _targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty)) {
                if (IsPrimitive(prop) && prop.CanRead && prop.CanWrite) {
                    try {
                        object value = prop.GetValue(from, null);
                        prop.SetValue(to, value, null);
                    } catch (Exception e) {
                        throw new Exception(string.Format("Failed to clone propery of {0}.{1}", prop.DeclaringType.Name, prop.Name));
                    }
                }
            }
        }

        private bool IsPrimitive(PropertyInfo prop) {
            if (prop.Name.ToUpper() == "ID") {
                return false;
            }
            return new Type[] {typeof(bool?), typeof(bool), typeof(string), typeof(int), typeof(decimal), typeof(DateTime), typeof(int?), typeof(decimal?), typeof(Guid)}.Contains(prop.PropertyType);
        }
    }
}

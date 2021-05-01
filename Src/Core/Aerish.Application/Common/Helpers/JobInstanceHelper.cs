using System;
using System.Reflection;

namespace Aerish.Application.Common.Helpers
{
    public static class JobInstanceHelper
    {
        public static object NewInstance(string assembly, string className, params object[] args)
        {
            Assembly a = Assembly.Load(assembly);
            Type t = a.GetType(className);
            var instance = Activator.CreateInstance(t, args);

            return instance;
        }

        public static T NewInstance<T>(string assembly, string className, params object[] args) where T : class
        {
            var instance = NewInstance(assembly, className, args);

            if (!typeof(T).IsAssignableFrom(instance.GetType()))
            {
                throw new AerishException($"Instance helper expecting {typeof(T).Name} but getting {instance.GetType()}");
            }

            return (T)instance;
        }
    }
}

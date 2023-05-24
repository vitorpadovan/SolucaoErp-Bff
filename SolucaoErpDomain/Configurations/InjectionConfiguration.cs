using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoErpDomain.Configurations
{
    public static class InjectionConfiguration
    {
        public static IServiceCollection AddDependencieInjections(this IServiceCollection services)
        {
            Type[] tInterfaces = new Type[] { typeof(ISingletonDependecy<,>), typeof(IScopedDependecy<,>), typeof(ITransientDependecy<,>) };
            var assem = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Type tInterface in tInterfaces)
            {
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    var types = GetAllTypesImplementingOpenGenericType(tInterface, assembly);
                    foreach (Type type in types)
                    {
                        var iImplementedInterface = type.GetInterfaces()
                            .SingleOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == tInterface, null);
                        if (iImplementedInterface != null)
                        {
                            if (tInterface == typeof(ISingletonDependecy<,>))
                            {
                                services.AddSingleton(iImplementedInterface.GenericTypeArguments[0], iImplementedInterface.GenericTypeArguments[1]);
                            }

                            if (tInterface == typeof(IScopedDependecy<,>))
                            {
                                services.AddScoped(iImplementedInterface.GenericTypeArguments[0], iImplementedInterface.GenericTypeArguments[1]);
                            }

                            if (tInterface == typeof(ITransientDependecy<,>))
                            {
                                services.AddTransient(iImplementedInterface.GenericTypeArguments[0], iImplementedInterface.GenericTypeArguments[1]);
                            }
                        }
                    }
                }
            }
            return services;
        }
        public static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(Type openGenericType, Assembly assembly)
        {
            return from x in assembly.GetTypes()
                   from z in x.GetInterfaces()
                   let y = x.BaseType
                   where
                   (y != null && y.IsGenericType &&
                   openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition())) ||
                   (z.IsGenericType &&
                   openGenericType.IsAssignableFrom(z.GetGenericTypeDefinition()))
                   select x;
        }
    }
}

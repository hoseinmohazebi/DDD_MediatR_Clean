using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Shared.Infrastructure.Extentions
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Dynamicaly load all IEntityTypeConfiguration with Reflection
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="assemblies">Assemblies contains Entities</param>
#nullable disable
        public static void RegisterEntityTypeConfiguration(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            MethodInfo applyGenericMethod = typeof(ModelBuilder).GetMethods().First(m => m.Name == nameof(ModelBuilder.ApplyConfiguration));

            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic);


            foreach (Type type in types)
            {
                if (type != null)
                {
                    foreach (Type iface in type.GetInterfaces())
                    {
                        if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                        {
                            MethodInfo applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);

                            applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        }
                    }

                }
            }
        }
    }
}

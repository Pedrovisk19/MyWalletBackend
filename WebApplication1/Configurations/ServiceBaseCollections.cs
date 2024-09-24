using MyWallet.BaseCollections;
using System.Reflection;

namespace MyWallet.Configurations
{
    public static class ServiceBaseCollections
    {
        public static void AddDynamicServices(this IServiceCollection services, Assembly assembly)
        {
            // Encontre todos os tipos que herdam de BaseService
            var serviceTypes = assembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(BaseService<>)) && !type.IsAbstract);

            foreach (var serviceType in serviceTypes)
            {
                // Registre o serviço com escopo
                services.AddScoped(serviceType);
            }
        }
    }
}

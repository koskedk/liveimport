using Microsoft.Extensions.DependencyInjection;

namespace LiveImport.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection  AddCore(this IServiceCollection services)
        {
            services.AddSingleton<UploadStateMachine>();
            return services;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using bigHomeWork.Services;
using bigHomeWork.Services.Facades;

namespace bigHomeWork.App
{
    public static class DependencyInjection
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Регистрация фасадов
            services.AddSingleton<CategoryFacade>();
            services.AddSingleton<OperationFacade>();
            services.AddSingleton<BankAccountFacade>();

            // Регистрация сервисов
            services.AddSingleton<IDataService, DataService>(); // Регистрация IDataService
            services.AddSingleton<DataServiceProxy>();

            // Регистрация импортера
            services.AddSingleton<IDataImporter, JsonDataImporter>(); // JsonDataImporter зависит от IDataService

            return services.BuildServiceProvider();
        }
    }
}
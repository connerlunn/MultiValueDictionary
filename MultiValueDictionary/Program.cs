namespace MultiValueDictionary
{
    using Microsoft.Extensions.DependencyInjection;
    using MultiValueDictionary.Services;
    using MultiValueDictionary.Managers;

    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IDictionaryService, DictionaryService>();
            services.AddTransient<IDictionaryManager, DictionaryManager>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            // entry to run app 
            serviceProvider.GetService<IDictionaryService>()!.Run();
        }
    }
}
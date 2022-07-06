namespace MultiValueDictionary
{
    using Microsoft.Extensions.DependencyInjection;
    using MultiValueDictionary.Services;
    using MultiValueDictionary.Managers;
    using MultiValueDictionary.Utilities;

    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IDictionaryService, DictionaryService>();
            services.AddTransient<IDictionaryManager, DictionaryManager>();
            services.AddTransient<IConsoleUtil, ConsoleUtil>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<IDictionaryService>()!.Run(false);
        }
    }
}
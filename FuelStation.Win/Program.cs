using FuelStation.EF.Repository;
using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.Extensions.DependencyInjection;

namespace FuelStation.Win
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();


            

            services.AddDbContext<FuelStationContext>();


            
            services.AddSingleton<IEntityRepo<Customer>, CustomerRepo>();
            services.AddSingleton<IEntityRepo<Item>, ItemRepo>();
            //services.AddSingleton<IEntityRepo<Transaction>, TransactionRepo>();
            //services.AddSingleton<IEntityRepo<TransactionLine>, TransactionLineRepo>();

            //services.AddSingleton<CustomerForm>();
            //services.AddSingleton<ItemForm>();
            services.AddSingleton<MainForm>();


            ServiceProvider = services.BuildServiceProvider();
            var mainForm = ServiceProvider.GetRequiredService<MainForm>();

            Application.Run(mainForm);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
using WestWindSystem.DAL;
#endregion

namespace WestWindSystem
{
    public static class WestWindExtensions
    {
        //this is a method of the extension class which will be call from the
        //   Program.cs file of the Web Application
        //this method will do 2 things
        //  register the context connection string
        //  register ALL services that I create within the BLL layer classes
        public static void WestWindExtensionServices(this IServiceCollection services,
                Action<DbContextOptionsBuilder> options)
        {
            //handle the connection string
            //add my context class to the services (IServiceCollection)
            services.AddDbContext<WestWindContext>(options);

            //register ANY BLL service class
            //to register a service class you will use the IServiceCollection method .AddTransient<T>
            //for any outside coding that requires access to one of my coded service
            //      you MUST register the service
            services.AddTransient<WestWindAbout>((serviceProvider) =>
                {
                    var context = serviceProvider.GetService<WestWindContext>();
                    //create an instance of the service class and register said class in IServiceCollection
                    //once the class has been registered, it can be used by ANY outside source of your class library
                    return new WestWindAbout(context);
                });
            services.AddTransient<RegionServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<WestWindContext>();
                //create an instance of the service class and register said class in IServiceCollection
                //once the class has been registered, it can be used by ANY outside source of your class library
                return new RegionServices(context);
            });
            services.AddTransient<CategoryServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<WestWindContext>();
                //create an instance of the service class and register said class in IServiceCollection
                //once the class has been registered, it can be used by ANY outside source of your class library
                return new CategoryServices(context);
            });
            services.AddTransient<ProductServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<WestWindContext>();
                //create an instance of the service class and register said class in IServiceCollection
                //once the class has been registered, it can be used by ANY outside source of your class library
                return new ProductServices(context);
            });
        }
    }
}

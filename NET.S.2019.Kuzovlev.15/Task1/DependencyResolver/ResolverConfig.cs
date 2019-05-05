using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IStorage>().To<AccountStorage>();
            kernel.Bind<IService>().To<AccountService>();
            kernel.Bind<Account>().To<BaseAccount>();
            kernel.Bind<Account>().To<GoldAccount>();
            kernel.Bind<Account>().To<PlatinumAccount>();
        }
    }
}

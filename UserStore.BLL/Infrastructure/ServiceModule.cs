using Ninject.Modules;
using UserStore.DAL.Interfaces;
using UserStore.DAL.Repositories;

namespace UserStore.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
            //Bind<IUploadImageService>().To<LocalUploader>();
        }
    }
}

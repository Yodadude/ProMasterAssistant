using System.Web;
using NPoco;
using ProMasterAssistant.Infrastructure;
using StructureMap;

namespace ProMasterAssistant {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                        scan.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                                        scan.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<,>));
                                    });
                            x.For<IDatabase>().HttpContextScoped().Use(sm =>
                                {
                                    var factory = sm.GetInstance<IDatabaseFactory>();
                                    return factory.Create();
                                });
                        });
            return ObjectFactory.Container;
        }
    }
}
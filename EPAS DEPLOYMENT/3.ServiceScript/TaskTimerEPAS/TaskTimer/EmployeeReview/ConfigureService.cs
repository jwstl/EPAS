using Topshelf;

namespace WindowsServiceWithTopshelf
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(
                configure =>
                {
                    configure.Service<>(
                        service =>
                        {
                            service.ConstructUsing(s => new TaskTimerService());
                            service.WhenStarted(s => s.Start());
                            service.WhenStopped(s => s.Stop());
                        });
                    //Setup Account that window service use to run.
                    configure.RunAsLocalSystem();
                    configure.SetServiceName("MyWindowServiceWithTopshelf");
                    configure.SetDisplayName("MyWindowServiceWithTopshelf");
                    configure.SetDescription("My .Net windows service with Topshelf");
                }
                );
        }
    }
}

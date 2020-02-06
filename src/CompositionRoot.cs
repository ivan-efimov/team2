using DataLayer.GameService;
using LightInject;

namespace thegame
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IGameService, GameService>(new PerContainerLifetime());
            
        }
    }
}
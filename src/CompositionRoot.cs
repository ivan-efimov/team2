using DataLayer.Actions;
using DataLayer.GameService;
using LightInject;

namespace thegame
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IGameStorage, GameStorage>(new PerContainerLifetime());
            serviceRegistry.Register<IActionChainPerformer, ActionChainPerformer>();
            serviceRegistry.Register<IActionFactory, ActionFactory>();
        }
    }
}
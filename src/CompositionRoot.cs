using DataLayer.Actions;
using DataLayer.GameService;
using DataLayer.LevelFactories;
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
            serviceRegistry.Register<IGameService, GameService>();
            serviceRegistry.Register<ITurnService, TurnService>();

            serviceRegistry.Register<ILevelFactory, TxtLevelFactory>();
        }
    }
}
using System.Linq;
using DataLayer;
using DataLayer.Game;
using DataLayer.Game.Actions;
using DataLayer.Game.Field;
using DataLayer.Game.InteractionRules;
using DataLayer.Game.LevelFactory;
using LightInject;
using thegame.InputConverter;

namespace thegame
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            // All cell types
            serviceRegistry.Register<ICell, PlayerCell>("PlayerCell");
            serviceRegistry.Register<ICell, WallCell>("WallCell");
            serviceRegistry.Register<ICell, BoxCell>("BoxCell");
            serviceRegistry.Register<ICell, TargetCell>("TargetCell");
            
            // All cell-cell interaction types (only for player-cell & box-cell cases jet)
            serviceRegistry.Register<ICellInteractionRule, PlayerBoxInteractionRule>("Player-Box");
            serviceRegistry.Register<ICellInteractionRule, PlayerWallInteractionRule>("Player-Wall");
            serviceRegistry.Register<ICellInteractionRule, PlayerSpaceInteractionRule>("Player-Space");
            serviceRegistry.Register<ICellInteractionRule, PlayerTargetInteractionRule>("Player-Target");
            serviceRegistry.Register<ICellInteractionRule, BoxBoxInteractionRule>("Box-Box");
            serviceRegistry.Register<ICellInteractionRule, BoxWallInteractionRule>("Box-Wall");
            serviceRegistry.Register<ICellInteractionRule, BoxSpaceInteractionRule>("Box-Space");
            serviceRegistry.Register<ICellInteractionRule, BoxTargetInteractionRule>("Box-Target");

            serviceRegistry.Register<ICellInteractionRuleProvider>( factory => new CellInteractionRuleProvider(
                        factory.GetAllInstances<ICellInteractionRule>().ToArray()),
                    new PerContainerLifetime());

            serviceRegistry.Register<ICellFactory>(factory => new CellFactory(
                        factory.GetAllInstances<ICell>().ToArray()),
                    new PerContainerLifetime());
            serviceRegistry.Register<ILevelFactory, TxtLevelFactory>(new PerContainerLifetime());
            serviceRegistry.Register<IActionEvolver, ActionEvolver>();
            serviceRegistry.Register<IActionChainFactory, ActionChainFactory>();
            
            serviceRegistry.Register<IGameStorage>(factory => new GameStorage(() =>
                new SokobanGame(factory.GetInstance<ILevelFactory>().Create("level1.txt"), // TODO
                    factory.GetInstance<IActionChainFactory>(),
                    cellsDump => cellsDump // GameOver condition
                        .Where(tup => tup.Item2 // check if target cells
                            .Any(cell => cell is TargetCell))
                        .All(tup => tup.Item2 // All have a box on them
                            .Any(cell => cell is BoxCell)))),
                new PerContainerLifetime());
            serviceRegistry.Register<IGameService, GameService>();

            serviceRegistry.Register<IInputToCommandConverter, InputToCommandConverter>();
        }
    }
}
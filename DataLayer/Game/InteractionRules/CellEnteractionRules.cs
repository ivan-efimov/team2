using System;
using System.Drawing;
using DataLayer.Game.Actions;
using DataLayer.Game.Field;

namespace DataLayer.Game.InteractionRules
{
    public interface ICellInteractionRule
    {
        IAction NextAction(IAction previousAction);
        Type ActorType { get; }
        Type TargetType { get; }
    }

    public class PlayerBoxInteractionRule : ICellInteractionRule
    {
        public IAction NextAction(IAction previousAction)
        {
            switch (previousAction)
            {
                case MoveAction moveAction:
                    return new MoveAction
                    {
                        ActorPoint = moveAction.TargetPoint,
                        TargetPoint = moveAction.TargetPoint.Add(
                            moveAction.TargetPoint.Subtract(
                                moveAction.ActorPoint))
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(previousAction));
            }
        }

        public Type ActorType => typeof(PlayerCell);
        public Type TargetType => typeof(BoxCell);
    }

    public class PlayerWallInteractionRule : ICellInteractionRule
    {
        public IAction NextAction(IAction previousAction)
        {
            switch (previousAction)
            {
                case MoveAction moveAction:
                    return new FailAction();
                default:
                    throw new ArgumentOutOfRangeException(nameof(previousAction));
            }
        }

        public Type ActorType => typeof(PlayerCell);
        public Type TargetType => typeof(WallCell);
    }

    public class PlayerSpaceInteractionRule : ICellInteractionRule
    {
        public IAction NextAction(IAction previousAction)
        {
            switch (previousAction)
            {
                case MoveAction moveAction:
                    return new SuccessAction();
                default:
                    throw new ArgumentOutOfRangeException(nameof(previousAction));
            }
        }

        public Type ActorType => typeof(PlayerCell);
        public Type TargetType => null;
    }

    public class BoxBoxInteractionRule : ICellInteractionRule
    {
        public IAction NextAction(IAction previousAction)
        {
            switch (previousAction)
            {
                case MoveAction moveAction:
                    return new FailAction();
                    // return new MoveAction
                    // {
                    //     ActorPoint = moveAction.TargetPoint,
                    //     TargetPoint = moveAction.TargetPoint.Add(
                    //         moveAction.TargetPoint.Subtract(
                    //             moveAction.ActorPoint))
                    // };
                default:
                    throw new ArgumentOutOfRangeException(nameof(previousAction));
            }
        }

        public Type ActorType => typeof(BoxCell);
        public Type TargetType => typeof(BoxCell);
    }

    public class BoxWallInteractionRule : ICellInteractionRule
    {
        public IAction NextAction(IAction previousAction)
        {
            switch (previousAction)
            {
                case MoveAction moveAction:
                    return new FailAction();
                default:
                    throw new ArgumentOutOfRangeException(nameof(previousAction));
            }
        }

        public Type ActorType => typeof(BoxCell);
        public Type TargetType => typeof(WallCell);
    }

    public class BoxSpaceInteractionRule : ICellInteractionRule
    {
        public IAction NextAction(IAction previousAction)
        {
            switch (previousAction)
            {
                case MoveAction moveAction:
                    return new SuccessAction();
                default:
                    throw new ArgumentOutOfRangeException(nameof(previousAction));
            }
        }

        public Type ActorType => typeof(BoxCell);
        public Type TargetType => null;
    }

    public class PlayerTargetInteractionRule : ICellInteractionRule
    {
        public IAction NextAction(IAction previousAction)
        {
            switch (previousAction)
            {
                case MoveAction moveAction:
                    return new SuccessAction();
                default:
                    throw new ArgumentOutOfRangeException(nameof(previousAction));
            }
        }

        public Type ActorType => typeof(PlayerCell);
        public Type TargetType => typeof(TargetCell);
    }

    public class BoxTargetInteractionRule : ICellInteractionRule
    {
        public IAction NextAction(IAction previousAction)
        {
            switch (previousAction)
            {
                case MoveAction moveAction:
                    return new SuccessAction();
                default:
                    throw new ArgumentOutOfRangeException(nameof(previousAction));
            }
        }

        public Type ActorType => typeof(BoxCell);
        public Type TargetType => typeof(TargetCell);
    }
    
    
}
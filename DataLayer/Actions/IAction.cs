using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DataLayer.Actions
{
    public interface IAction
    {
        Point ActionPoint { get; set; }
    }

    public class SuccessAction : IAction
    {
        public Point ActionPoint { get; set; }
    }
    public class FailAction : IAction
    {
        public Point ActionPoint { get; set; }
    }
}
